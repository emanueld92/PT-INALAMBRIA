# PT-INALAMBRIA

Prueba tecnica para el cargo de Semi-senior

## Como iniciar la api

### Desde Docker:

Use Docker para inicializar Domino.Api con el siguiente comando:

PD: Este proceso puede tardar varios minutos

```bash
docker-compose up --build
```

### Desde Visual Studio

Abrir visual Studio y Seleccionar open a project or solution:

[![abrir-proyecto.png](https://i.postimg.cc/65nTts5H/abrir-proyecto.png)](https://postimg.cc/ppVPJ6j8)

seleccionar archivo Inalambria.Domino.sln

[![seleccionar-archivo.png](https://i.postimg.cc/4dxhxWFY/seleccionar-archivo.png)](https://postimg.cc/xkBds3QQ)

Iniciar con el botón Docker Compose:

[![Boton-de-Dockercompose.png](https://i.postimg.cc/XJ5XJtk7/Boton-de-Dockercompose.png)](https://postimg.cc/dkqJNHfz)

## Probar la API:

### Desde el Navegador:

esperar que cargue el api, al terminar de carga se abrirá una pestaña del navegador:

[![api-desde-el-navegador.png](https://i.postimg.cc/3r155n2s/api-desde-el-navegador.png)](https://postimg.cc/XXrD9KHL)

### Desde Postman

abrir postman e importar el archivo Inalambria.PT.postman_collection.json que se encuentra en el repositorio:
sustituir el puerto de la peticiones en postman con el puerto de la url que se muestra en la pestaña del navegador:

[![request-Auth.png](https://i.postimg.cc/L8Z54nBF/request-Auth.png)](https://postimg.cc/SnkkDQvg)

obtenemos nuestro JWT con el cual vamos autorizar las peticiones que le hacemos al api

## formato de body para las peticiones a nuestra endPoint /api/Domino/GetDomino:

[![formato-valido.png](https://i.postimg.cc/GpZd6PSs/formato-valido.png)](https://postimg.cc/B8crKF3q)

### Ejmplos de lista de fichas Validas

```bash
 ["[1|2]", "[2|3]", "[4|4]", "[4|3]", "[4|1]", "[1|1]"]
```

```bash
 ["[1|2]", "[4|3]", "[4|1]", "[2|3]"]
```

### Ejmplos de lista de fichas Invalidos

```bash
 ["[1|2]", "[2|3]", "[4|4]", "[3|3]", "[4|1]", "[1|1]"]
```

```bash
 ["[1|2]"]
```

## License

[MIT](https://choosealicense.com/licenses/mit/)
