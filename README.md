# ConsultaMetrobus

_Proyecto para consultar API de Ubicacion de Unidades de Metrobus y guardar los datos_
_en una base de datos Postgresql para posteriormente exponer un Servicio API rest para consulta_

## Comenzando

_A continuación damos las instrucciones del proyecto._

##Instrucciones

### Descarga del proyecto 

_Se proporciona la liga para la descarga del proyecto_

```
git clone https://github.com/rodrigo4780/ConsultaMetrobus.git
```

docker build -t postgresmetrobus -f Dockerfilebase .
docker run --name base -d -p 5432:5432 postgresmetrobus

Para ver ip
docker inspect base

docker build -t consultametrobus -f Dockerfile2 .
docker run -d -e host=172.17.0.2 --name consulta consultametrobus

docker build -t serviciometrobus .
docker run -d -p 80:80 -e host=172.17.0.2 --name servicio serviciometrobus
