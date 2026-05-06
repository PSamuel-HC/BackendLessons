# Data Migration Versioning

## What is Data Migration Versioning?

As an application evolves, its data model almost never stays the same. New features require new fields, existing structures need to be reorganized, and sometimes entire tables or collections have to be redesigned. The database does not change automatically, so these adjustments have to be applied in a controlled way. This process is known as a **data migration**.

A data migration is a set of explicit changes that transform the current state of the data into a new one expected by the application. These changes can include creating or modifying tables, adding or removing fields, or updating existing records to match a new format.

Data migration versioning is the practice of organizing migrations as a sequence of ordered, identifiable steps. Each migration has a version or identifier, and the system keeps track of which ones have already been executed. This ensures that every environment applies the same changes in the same order, avoiding inconsistencies and reducing human error.

In practice, this means treating database changes similarly to application code: they are incremental, versioned, and reproducible. Instead of manually modifying the database, developers define migrations that can be applied automatically and safely across different environments.

## How It Was Done Before

Before NoSQL databases got popular, most applications used to store their data in relational databases like SQL server, MySQL or PostgreSQL. There databases are built around tables with a fixed structure, that means every row inside the table had to have the same format. The issue was that as an application grew and changed, that structure needed to change too.

To handle those changes, developers used a series of numbered SQL files. Each file represented a specific modification to the database and was stored with the app code:

```
001_create_users_table.sql
002_add_email_to_users.sql
003_add_phone_to_users.sql
```

Each script contained the raw SQL instruction for that change:

```sql
-- 003_add_phone_to_users.sql
ALTER TABLE Users
ADD Phone VARCHAR(20) NULL;
```

To keep track of which changes had already been applied in a environment (like development, staging or prod) a table inside the database recorded all executed migrations. During deployment, the system would check which scripts hadn't been run yet and apply only those, making sure every environment stayed in sync.

```
| version | filename                      | applied_at          |
|---------|-------------------------------|---------------------|
| 001     | 001_create_users_table.sql    | 2024-01-01 10:00:00 |
| 002     | 002_add_email_to_users.sql    | 2024-01-15 09:30:00 |
| 003     | 003_add_phone_to_users.sql    | 2024-02-01 14:00:00 |
```

Even tho this worked, it led to some problems:

- **Downtime** — large structural changes could lock database tables for minutes or hours while they ran, making the application unavailable.
- **Unreliable rollbacks** — reversing a migration required a separate undo script, which teams rarely wrote with care.
- **Team conflicts** — if two developers created migrations at the same time on different branches, numbering conflicts were common and annoying to fix.
- **All-or-nothing** — every environment had to stay perfectly in sync, and missing a single script could lead to bugs that were hard to track down.

## How It Is Done Now — The NoSQL Approach

As we know, NoSQL is based on being a flexible alternative for SQL, mainly on not having a rigid schema, but rather letting the "documents" (the equivalent of rows) having their own shape, and so being able of managing unstructured and semi-structured data sets.

Because of this, the NoSQL approach for migrations is handled differently than MySQL. The responsibility of managing the structure moves from the database to the application, on something called the **_schema-on-read_**

Instead of a global changelog table, each document carries its own version field:

```json
{
  "id": "154432",
  "schemaVersion": "1.0",
  "name": "Ana López",
  "address": {
    "street": "Calle 10",
    "city": "Medellín"
  }
}
```

This means different documents in the same collection can exist at different schema versions simultaneously — and this is intentional, not a flaw. The following are 4 types of managing nosql migrations:

### Lazy Migration

With Lazy migration (the one being used the most), documents are upgraded only when they are actually read. The application checks the version field on each read, upgrades the document if it is outdated, and saves the new version back to the database before returning it to the caller. This requires zero downtime and has no upfront cost, but the application must be able to understand and upgrade every historic version that may still exist in the database.

### Eager/Batch Migration

With this approach, all documents are updated to the new schema version. The cost of this approach is downtime and the heavy load of updating n amount of documents at once.

### Hybrid Migration

Is possible to have a combination of approaches, where a background process updates gradually the out of date documents while the application still needs to be able to handle the difference of versions from the documents and update them too. This is also common on production systems to avoid downtime.

### Versioned Schema

In this other alternative, old documents are never modified. Instead, the application creates new documents for every version with the corresponding schema change, permanently maintains support for every schema version that has ever existed, routing each document to the correct handler based on its version field. Ideal for audit logs, financial records, or any system where historical accuracy is critical and data must never be altered after it is written.

### Comparison

|                         | Eager          | Lazy               | Hybrid                  | Versioned                |
| ----------------------- | -------------- | ------------------ | ----------------------- | ------------------------ |
| **Downtime risk**       | Medium         | None               | None                    | None                     |
| **Upfront cost**        | High           | None               | Low                     | None                     |
| **Old version support** | Not needed     | Yes                | Temporary               | Permanent                |
| **Best for**            | Small datasets | Large or cold data | Most production systems | Audit logs, event stores |

---

### Conclusions

Data migration versioning is a key practice for keeping the database aligned with the application as both evolve over time. Without it, changes become error-prone, hard to track, and difficult to reproduce across environments.

In relational databases, migrations are usually structured and strict: every change must be defined, versioned, and applied in order. This provides consistency and control, but requires careful planning, since changes often affect the entire database at once.

In contrast, NoSQL databases take a more flexible approach. Since they do not enforce a rigid schema, migrations are often handled at the data level, allowing systems to evolve gradually. Applications can support multiple versions of the same data, and updates can happen progressively instead of all at once.

### Example in code:

### Example 1 - Document versioning

```csharp

#region Example1

// Document versioning (without physical migration)
var user = await collection.Find(u => u.Name == "Juan").FirstOrDefaultAsync();

if (user.Version == 1)
{
    user.Email = "Without Email";
}

Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
#endregion

```

### Example 2 - Lazy, migration on read

```csharp
#region Example 2

var user2 = await collection.Find(u => u.Name == "Juan").FirstOrDefaultAsync();

if (user2.Version == 1)
{
    // Lazy, migration on read
    var update = Builders<User>.Update
        .Set("Email", "Without Email")
        .Set("Version", 2);

    var filter = Builders<User>.Filter.Eq(u => u.Name, "Juan");

    await collection.UpdateOneAsync(filter, update);

    Console.WriteLine("Migration Applied");
}

#endregion
```
