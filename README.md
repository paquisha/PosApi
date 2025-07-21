# PosApi
plantilla base
## crear la DB
ingresa en el directorio final

instar dependencias
```shell
amarumed-back/yarn install
amarumed-front/yarn install
```

## crear la DB

Para inicializar una DB de prueba ejecutar las siguientes lineas de comando.

```shell
createdb -U postgres amarumed
```

Si se crea por primera vez la base de datos.
```shell
createdb -U postgres amarumed
yarn build 
yarn migrate
```
Si desea borrar y crearla nuevamente.
```shell
dropdb -U postgres amarumed 
createdb -U postgres amarumed 
yarn build 
yarn migrate
```

## ejecutar los scripts de /sql
en el gestor de base de datos
```shell
sql/ROLES.sql
sql/MEDICALEXAMS.sql
sql/etc..
```

## levantar la app
```shell
amarumed-back/yarn serve
amarumed-front/yarn serve
```