# Database Versioning
**Presented by:** 
* Gerónimo Le Lan Toussaint
* Luigi Cabrera Huanqui
* German Alvarez Copa
* Bruno Salinas Velez

---

# 1. What is database versioning?

It is the practice of treating every SQL schema change as a versioned, ordered, and reversible artifact. It is not just about saving files — it is about keeping a record of which changes were applied, in what order, when, and in which environment.

It covers three types of changes:

- **Structure changes:** CREATE TABLE, ALTER TABLE, DROP COLUMN
- **Seed data changes:** INSERT of master or configuration data
- **Permission and object changes:** roles, indexes, views

The goal is that any environment (DEV, TEST, PROD) can reproduce the exact same database state at any point in time.

---

# 2. How It Was Done Before

Before dedicated migration tools existed, teams relied on general-purpose database clients and manual processes. These were not versioning tools — they were execution tools. The responsibility of tracking what had been applied fell entirely on the developer.

The most common tools and approaches were:

- **SQL*Plus (Oracle, 1980s):** Oracle's command-line client. DBAs wrote .sql scripts and ran them manually against the database. No history, no order enforcement.
- **MySQL CLI / psql (1990s):** Native clients of MySQL and PostgreSQL. Used to run scripts by hand with no tracking of what had already been executed.
- **SSMS — SQL Server Management Studio (2000s):** A GUI tool by Microsoft. DBAs kept scripts in Windows folders numbered by hand and ran them from the interface.
- **Toad (2000s):** A popular GUI for Oracle and SQL Server. It allowed running scripts but had no concept of which ones had already been applied.
- **Numbered .sql folders:** The most widespread approach across all eras. A folder containing files like 001_init.sql, 002_add_column.sql. No tooling, pure manual discipline.
- **.bat / .sh scripts:** Custom shell scripts that called the SQL client in sequence. Homemade, fragile, and impossible to maintain across teams.

The common problem across all of these tools is the same: none of them knew if a script had already been run in a given environment.

---

# 3. Why is Git for .sql files not enough?

Git keeps a file history, but it knows nothing about the state of the database. The concrete problems are:

- **No guaranteed order:** Git does not know which scripts to run or in what sequence.
- **No application state:** It does not record which scripts have already been executed in each environment.
- **No idempotency:** Running the same .sql file twice can break the database.
- **No defined rollback:** There is no mechanism to undo a change that has already been applied.

A migration tool solves all of these problems by maintaining a history table inside the database that records exactly what was applied and when.

**Idempotency** is a key concept in this context. A migration script is idempotent when it can be run multiple times and always produces the same result without causing errors or duplicate data. For example, using IF NOT EXISTS when creating a table ensures the script does not fail if the table already exists. This property is essential for CI/CD pipelines where a migration might be retried automatically after a failure.

---

# 4. The State Problem

Modifying schemas with live data is the central challenge of database versioning. When the database is empty, any change is safe. In production, with real data, the same change can have serious consequences.

The three possible scenarios are:

- **Ideal scenario:** the schema is empty and an ALTER TABLE is executed. There is no risk.
- **Real scenario:** there are millions of rows and a NOT NULL column is added without a DEFAULT value. Existing rows have no value for that column and the migration fails.
- **Dangerous scenario:** a DROP COLUMN is executed in production. Data loss is immediate and irreversible.

For this reason, every migration must consider not only what changes in the schema, but how it affects the data that already exists.

---

# 5. Schema Drift and Consistency Across Environments

**Drift** is the deviation that occurs when the database schema in one environment differs from the source code or from other environments, because someone applied changes manually without going through the pipeline.

A typical example is the following: a developer connects directly to production and runs an emergency ALTER TABLE. The change is not recorded in Git or in the migration history. Production ends up with a column that DEV does not have, and nobody knows when it happened or who did it.

The result without versioning is that environments progressively fall out of sync:

- **DEV** has all tables up to date.
- **TEST** is missing some recent migration.
- **PROD** is even further behind.

With versioned migrations this problem cannot occur, because the only thing that modifies the database is the tool, and it keeps everything recorded. All environments run the same files in the same order, which guarantees schemas that are always in sync.



<br><br>



# Data Versioning Strategies and Methodologies


## 1. Migration-Based Approach
This approach is also known as evolutionary. Database changes are treated as an ordered sequence of state transitions.

Instead of defining the final result, it defines step by step how to transform the database from its current state to the next.

### Mechanism: Up and Down Scripts
Each change consists of two essential parts:
* **Up Method (Forward):** Contains the ordered instructions to apply a change.
    * *Example:* `CREATE TABLE usuarios` o `ALTER TABLE productos ADD COLUMN precio`.
* **Down Method (Rollback):** Contains the reverse instructions to undo exactly what the Up method did.
    * *Example:* If the Up method created a table with `CREATE TABLE usuarios`, the Down method should execute `DROP TABLE usuarios`.

This method is ideal for maintaining a clear history of changes and facilitating collaboration in development teams.

---

## 2. State-Based Approach
The declarative approach focuses on the desired final state.

The source code represents the complete schema (tables, views, procedures) as the current version.

### The Schema Diff Process
This method uses a comparison tool (such as SQL Server Data Tools):
1.  **Source:** The SQL code defined in the repository.
2.  **Target:** The actual running database.
3.  **Generation:** The tool analyzes both and automatically generates a change script to align the target with the source.

---

## 3. Seed Data Versioning
Seeding is the process of populating a database with an initial set of information necessary for the system to start up and be tested.

### Seed Data Types
| Type | Description | Examples |
| :--- | :--- | :--- |
| **Master or Reference Static base information** | Static base information. Ensures identical IDs across all environments. | Countries, currencies, units of measure.
| **Configuration** | Technical parameters that define the app's behavior without manual intervention. | Roles, permissions, tax rates.
| **Test (Dummy Data)** | Fictitious records to simulate real-world usage, validate flows, and the interface during development. | Fake users, simulated sales history. |

### Implementation Mechanisms
* **Manual SQL Scripts:** `.sql` files that run after migrations. They offer universal compatibility.
* **Exchange Files (JSON/CSV):** Store information outside of SQL. They are easier to read and maintain.
* **Code-First Seeding:** Logic defined using an ORM in the programming language (C#, JS). Allows for the generation of complex random data.

### Management Strategies
1.  **Idempotent Seeding:** Scripts must be able to run multiple times without duplicating data, using Upsert logic (update if existing, insert if not).
2.  **Environment Separation:** It is crucial to separate production (real) data from development (fictitious) data to avoid critical errors on the real server.



<br><br>




# Data Migrations: Ecosystem and Practical Application
 
## 1. Tool Comparison: Independent Tools vs. ORMs
In modern backend development, we distinguish between specialized migration tools and those built into ORMs.
 
| Criterion | **Flyway** | **Liquibase** | **ORMs (EF Core, Prisma)** |
| :--- | :--- | :--- | :--- |
| **Language** | Plain SQL | XML, YAML, JSON, or SQL | C#, TypeScript, or Java |
| **Philosophy** | "SQL-First" and Simplicity | Abstraction and Flexibility | "Code-First" and Productivity |
| **Learning Curve**| Low (if you know SQL) | Medium (requires learning syntax) | Low for Devs / High for DBAs |
| **Best For** | Teams who want full SQL control | Complex, Multi-DB enterprise projects | Rapid development and sync with code |
 
 
 
---
 
## 2. Visual Demonstration: Folder Structure
Naming conventions are critical in migration tools like Flyway to ensure the correct execution order. This is how a professional project folder looks:
 
```text
BackendLessons/
├── src/
├── db/
│   └── migration/
│       ├── V1__init_schema.sql          <-- Baseline: Creates initial tables
│       ├── V2__add_phone_to_users.sql   <-- Incremental: Modifies existing schema
│       ├── V2.1__create_indexes.sql     <-- Minor version: Performance tuning
│       └── V3__seed_master_data.sql     <-- Data: Inserts initial configuration
└── flyway.conf
```
 
### Key Concepts:
*   **Version Prefix (`V`):** Defines the unique version number.
*   **Double Underscore (`__`):** Separates the version from the human-readable description.
*   **Checksum Validation:** The tool generates a unique hash for each file. If an applied file is modified, the tool will block execution to prevent environment drift.
 
 
 
---
 
## 3. Rollback Strategies: Handling Failures
When a deployment fails, we must have a strategy to restore the database state.
 
### A. Script-Based Rollbacks (Undo)
Some tools allow for "Down" scripts (e.g., `U1__undo_init.sql`).
*   **Pros:** Useful in development to reset environments quickly.
*   **Cons:** Extremely dangerous in production if they involve `DROP` commands, as data loss might occur.
 
### B. Forward-Only Migrations (Best Practice)
In high-availability systems, instead of "undoing," we create a new version (e.g., `V4`) that fixes the error or reverts the change safely.
*   **Why?** It maintains a linear history and ensures that the database state is never ambiguous.
 




<br><br>



# CI/CD aplicado a bases de datos

## ¿Qué es CI/CD?

CI/CD significa **Integración Continua** y **Entrega o Despliegue Continuo**.

En el desarrollo de software, CI/CD permite automatizar procesos como:

* Construcción del proyecto.
* Ejecución de pruebas.
* Validación de cambios.
* Despliegue de la aplicación.

Cuando se aplica a bases de datos, CI/CD también puede encargarse de ejecutar **migraciones SQL** de forma controlada. Esto permite que los cambios en la estructura de la base de datos avancen junto con los cambios de la aplicación.

---

## CI/CD en bases de datos

Una migración SQL puede incluir cambios como:

* Crear una tabla.
* Agregar una columna.
* Modificar un índice.
* Crear relaciones entre tablas.
* Insertar datos iniciales o datos semilla.

La importancia de aplicar CI/CD a bases de datos está en que la base de datos contiene información real.

A diferencia del código de una aplicación, la base de datos no puede simplemente reemplazarse por una nueva versión, porque almacena datos importantes para el sistema.

Por eso, los cambios deben realizarse de forma **ordenada, repetible y segura**.

---

## Importancia de automatizar migraciones SQL

Integrar migraciones SQL en un pipeline de CI/CD permite que cada cambio en la base de datos sea probado antes de llegar a producción.

Esto ayuda a evitar problemas como:

* Diferencias entre los ambientes de desarrollo, pruebas y producción.
* Scripts ejecutados en orden incorrecto.
* Cambios manuales que no quedan registrados.
* Errores al desplegar nuevas versiones de la aplicación.
* Riesgo de pérdida o corrupción de datos.

Con un proceso automatizado, las migraciones pueden validarse primero en un entorno de prueba o staging.

Si ocurre un error, el pipeline se detiene antes de afectar producción.

---

## Flujo básico de un pipeline con migraciones SQL

Un pipeline es una secuencia de pasos automáticos que se ejecutan cuando hay cambios en el repositorio.

Un flujo básico puede ser:

1. El desarrollador sube cambios al repositorio.
2. El pipeline clona el código.
3. Se instalan dependencias.
4. Se ejecutan pruebas automáticas.
5. Se levanta una base de datos temporal o de pruebas.
6. Se aplican las migraciones SQL.
7. Se valida que la aplicación funcione correctamente.
8. Si todo sale bien, se permite el despliegue.

Este proceso permite verificar que las migraciones no rompan la aplicación y que la base de datos quede sincronizada con la versión del sistema.

---

## Herramientas comunes

Para automatizar migraciones SQL dentro de un flujo CI/CD se pueden usar diferentes herramientas.

### Herramientas de CI/CD

* **GitHub Actions:** permite definir workflows directamente en un repositorio de GitHub.
* **GitLab CI:** permite configurar pipelines mediante un archivo `.gitlab-ci.yml`.
* **Jenkins:** permite crear pipelines personalizados para automatizar construcción, pruebas y despliegues.

### Herramientas para migraciones SQL

* **Flyway:** herramienta enfocada en migraciones versionadas, muy utilizada con scripts SQL.
* **Liquibase:** herramienta que permite manejar cambios de base de datos usando SQL, XML, YAML o JSON.
* **Docker:** útil para levantar bases de datos temporales durante pruebas automatizadas.

---

## Ejemplo de pipeline con GitHub Actions

El siguiente ejemplo muestra una configuración básica de un pipeline que ejecuta migraciones SQL:

```yaml
name: CI/CD Pipeline

on:
  push:
    branches:
      - main

jobs:
  build-and-migrate:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout code
        uses: actions/checkout@v2

      - name: Start test database
        run: |
          docker run --name test-db \
          -e POSTGRES_PASSWORD=secret \
          -d -p 5432:5432 postgres

      - name: Run migrations
        run: |
          ./migrate.sh

      - name: Run tests
        run: |
          ./run-tests.sh

      - name: Deploy application
        run: |
          ./deploy.sh
```

En este ejemplo, el pipeline se ejecuta cuando se realiza un `push` a la rama `main`.

Primero, se descarga el código del repositorio. Luego, se levanta una base de datos PostgreSQL de prueba usando Docker. Después, se ejecutan las migraciones SQL mediante un script llamado `migrate.sh`.

Posteriormente, se ejecutan las pruebas automáticas y, si todo sale correctamente, se despliega la aplicación.

---

## Explicación breve del pipeline

```yaml
name: CI/CD Pipeline
```

Define el nombre del workflow o pipeline.

```yaml
on:
  push:
    branches:
      - main
```

Indica que el pipeline se ejecutará cuando alguien haga un `push` a la rama `main`.

```yaml
jobs:
  build-and-migrate:
```

Define un trabajo llamado `build-and-migrate`.

```yaml
runs-on: ubuntu-latest
```

Indica que el trabajo se ejecutará en una máquina virtual con Ubuntu.

```yaml
steps:
```

Define la lista de pasos que ejecutará el pipeline.

```yaml
- name: Checkout code
  uses: actions/checkout@v2
```

Descarga el código del repositorio dentro del entorno del pipeline.

```yaml
- name: Start test database
  run: |
    docker run --name test-db \
    -e POSTGRES_PASSWORD=secret \
    -d -p 5432:5432 postgres
```

Levanta una base de datos PostgreSQL temporal usando Docker.

```yaml
- name: Run migrations
  run: |
    ./migrate.sh
```

Ejecuta el script encargado de aplicar las migraciones SQL.

```yaml
- name: Run tests
  run: |
    ./run-tests.sh
```

Ejecuta las pruebas automáticas del proyecto.

```yaml
- name: Deploy application
  run: |
    ./deploy.sh
```

Ejecuta el despliegue de la aplicación si los pasos anteriores fueron exitosos.


# Reglas de oro para migraciones SQL

## 1. No modificar migraciones ya aplicadas

Una migración que ya fue ejecutada no debería modificarse.

Si se necesita hacer un nuevo cambio, lo correcto es crear una nueva migración.

**Ejemplo:**

```text
V1__create_users_table.sql
V2__add_email_to_users.sql
V3__add_phone_to_users.sql
```

Si la migración `V2__add_email_to_users.sql` ya fue aplicada, no se debe editar.

Para agregar otro cambio, se crea una nueva migración, como `V3__add_phone_to_users.sql`.

Esto evita inconsistencias entre ambientes y mantiene un historial claro de cambios.

---

## 2. Crear una migración por cada cambio importante

Cada cambio relevante en la base de datos debe tener su propio archivo de migración.

**Ejemplo:**

```text
V1__create_products_table.sql
V2__add_price_to_products.sql
V3__create_orders_table.sql
V4__add_index_to_orders.sql
```

Esto permite identificar fácilmente:

* Qué cambió.
* Cuándo cambió.
* En qué orden debe ejecutarse.
* Qué migraciones ya fueron aplicadas.

---

## 3. Probar antes de producción

Las migraciones deben probarse antes de ejecutarse en producción.

Se recomienda probarlas en:

* Desarrollo.
* Staging.
* Una base de datos temporal con Docker.
* Un entorno similar a producción.

Esto ayuda a detectar:

* Errores de sintaxis.
* Problemas con datos existentes.
* Cambios que pueden afectar el funcionamiento de la aplicación.
* Incompatibilidades entre la aplicación y la base de datos.

---

## 4. Evitar cambios manuales en producción

No es recomendable modificar la base de datos directamente en producción usando herramientas como:

* DBeaver.
* pgAdmin.
* SQL Server Management Studio.
* Consolas SQL directas.

Todo cambio debería pasar por:

1. Un archivo de migración.
2. Control de versiones con Git.
3. Revisión del equipo.
4. Pipeline CI/CD.
5. Ejecución controlada.

Esto evita diferencias entre desarrollo, pruebas y producción.

---

## 5. Tener una estrategia de rollback

Rollback significa tener una forma de revertir o corregir un cambio si algo sale mal.

Algunas estrategias son:

* Crear scripts `down`.
* Restaurar un backup.
* Crear una migración correctiva.

En bases de datos reales, el rollback no siempre es simple.

Si una migración eliminó datos o cambió una estructura crítica, revertirla directamente puede ser riesgoso. En muchos casos, es más seguro crear una nueva migración que corrija el problema.

**Ejemplo de migración original:**

```sql
ALTER TABLE users
ADD COLUMN phone VARCHAR(20);
```

**Ejemplo de migración correctiva:**

```sql
ALTER TABLE users
ALTER COLUMN phone TYPE VARCHAR(30);
```

---

## 6. Hacer backups antes de cambios críticos

Antes de ejecutar cambios peligrosos, se recomienda tener un respaldo actualizado de la base de datos.

**Ejemplos de cambios críticos:**

```text
DROP TABLE
DROP COLUMN
ALTER COLUMN TYPE
DELETE masivo
UPDATE masivo
```

Un backup permite recuperar la información si algo falla durante la migración.

Esto es especialmente importante en ambientes de producción, donde la base de datos contiene información real del sistema.

---

## 7. Evitar cambios destructivos sin análisis

No se deberían eliminar columnas, tablas o datos sin revisar previamente si la aplicación todavía los utiliza.

Una forma más segura de realizar cambios destructivos es hacerlo por fases:

1. Agregar la nueva estructura.
2. Adaptar la aplicación.
3. Migrar los datos.
4. Verificar que todo funcione.
5. Eliminar la estructura antigua en otra migración.

Este enfoque reduce riesgos y permite que la aplicación y la base de datos evolucionen de manera controlada.



