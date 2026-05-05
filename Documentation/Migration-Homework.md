# Data Migrations Versioning



Investigate about data migrations versioning (except EF)



## 1. How it was done before?



### Manual SQL Scripts



They usually made a manual scripting in specific order, numerical order, for example



- 001_Create_Users_Table.sql

- 002_Add_Email_Column_To_Users.sql

- 003_Create_Orders_Table.sql



The number represented the execution order, the DBA or a senior backend developer used to execute these script in order in Staging and Production, if he/she failed, it could occur a problem and the scripting process would crash.



### Versioning Tables



Another way of control was write a versioning table. In these tables they write which script was executed and when it occur. The name of the file usually was DbVersion or SchemaLog.



Example:



| **Version** | **ScriptName** | **DateApplied** |

| --- | --- | --- |

| 1 | 001_Initial.sql | 2010-05-15 |

| 2 | 002_Add_Index.sql | 2010-05-20 |



### Comparison Tools (Redgate or SQL Delta)



Some enterprises used to adquire external services, they compared SQL Data, for example, data that they had had in that moment in their DB, the tool generate a script that added new information without deleting current information.



### Database Projects (SSDT)



Before EF market domination, Microsoft impulsed SSDT, in where, they write the “Final State” if the DB that had to be. They saved as SQL Server Database Projects (.sqlproj) and compare if it consisted when it was published.



### Embedded Migrations in the Code



If they didn’t want a complex ORM, they used to write and create their own SQL Motor in code, for example:



using (var connection = new SqlConnection(connString)) {

var currentVersion = GetDBCurrentVersion(connection);

var scripts = ObtainScriptsFrom Resources();



foreach (var script in scripts.Where(s => s.Id > currentVersion)) {

&#x20;   executeScript(script.Sql, connection);

&#x20;   UpdateDBVersionscript.Id, connection);

}



}



## 2. How it is done in other kinds of DBs (SQL, NoSQL)?



### SQL



Without EF, Versioning Scripts was the way, they usually had to use Flyway or Liquebase.



It usually created a history table, for example in flyway they created “flyway_schema_history”, the tool scanned the folder and looked for scripts that where not executed in sequencial order.



If they made a mistake, they should create a script with error, in Migrations they had to write 2 archives, one for Up and other for Down.



### NoSQL



#### Lazy Migration



Most Common way, they wrote the document, the mapper detected the missing field and gave default value. The problem is that if/else code would grow for managing versions.



#### Eager Migration



They wrote a document with the new format, for example in JS for Mongo we would write


```
db.users.updateMany(
    { age: { $exists: false } },
    { $set: { age: 18 } }
);
```


## 3. Basic example



### C# Before EF


```
public void ExecuteMigration() {
    using var connection = new SqlConnection("Connection String");
    connection.Open();


    // 1. Check Current Version
    int currentVersion = connection.QuerySingle<int>("SELECT COALESCE(MAX(Version), 0) FROM EsquemaLog");

    // 2. List of Scripts
    var scripts = new Dictionary<int, string> {
        { 1, "CREATE TABLE Product..." },
        { 2, "ALTER TABLE Product ADD Price..." }
    };

    // 3. Execute new elements
    foreach (var script in scripts.Where(s => s.Key > currentVersion)) {
        using var comand = new SqlCommand(script.Value, connection);
        comand.ExecuteNonQuery();

        // 4. Update Version Log
        connection.Execute("INSERT INTO EsquemaLog (Version) VALUES (@v)", new { v = script.Key })

    }
}
```


### Modern SQL (Without EF - DbUp Example)


```
var upgrader = DeployChanges.to
    .SqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()) // Read .sql
    .LogToConsole()
    .Build();

var result = upgrader.PerformUpgrade();

if (result.Successful) {
    Console.WriteLine("¡Updated DB!");
}
```

#### Migration Script
```
db.products.updateMany(
    { category: { $exists: false } }, 
    { $set: { category: "General" } } 
);
```


#### Lazy Migration

```
public class Product {
    public string Name { get; set; }


    // IF in DB "Price" don’t exist, BSON will assign 0 or any default value
    [BsonDefaultValue(0.0)]
    public double Precio { get; set; }



    // we can get obsolete data there
    [BsonExtraElements]
    public IDictionary<string, object> DatosAdicionales { get; set; }

}
```
