# ConsultaMetrobus
docker build -t postgresmetrobus -f Dockerfilebase .
docker run --name base -e POSTGRES_PASSWORD=rodrigo -d -p 5432:5432 postgresmetrobu
Para ver ip
docker inspect base
docker build -t consultametrobus -f Dockerfile2 .
docker run -d -e host=172.17.0.2 --name consulta consultametrobus

docker build -t serviciometrobus .
docker run -d -p 80:80 -e host=172.17.0.2 --name servicio serviciometrobus