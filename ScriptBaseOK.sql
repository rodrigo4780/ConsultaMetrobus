create table alcaldias(
alcaldia_id     varchar(10) constraint alcaldia_pk primary key,
alcaldia_nombre varchar(300)
);

insert into alcaldias(alcaldia_id, alcaldia_nombre) values('003', 'COYOACÁN');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('016', 'MIGUEL HIDALGO');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('008', 'LA MAGDALENA CONTRERAS');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('011', 'TLÁHUAC');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('002', 'AZTCAPOTZALCO');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('006', 'IZTACALCO');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('010', 'ALVARO OBREGON');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('013', 'XOCHIMILCO');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('017', 'VENUSTIANO CARRANZA');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('012', 'TLALPAN');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('004', 'CUAJIMALPA DE MORELOS');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('015', 'CUAUHTÉMOC');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('007', 'IZTAPALAPA');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('014', 'BENITO JUÁREZ');
insert into alcaldias(alcaldia_id, alcaldia_nombre) values('005', 'GUSTAVO A. MADERO');

create table records(
record_id       varchar(500) constraint record_pk primary key,
record_alcaldia_id      varchar(10) REFERENCES alcaldias (alcaldia_id),
vehicle_id      varchar(10),
trip_start_date varchar(20),
date_updated    varchar(20),
position_longitude      numeric(20,14),
trip_schedule_relationship      integer,
position_speed  integer,
position_latitude       numeric(20,14),
trip_route_id   varchar(20),
vehicle_label   varchar(20),
position_odometer       integer,
trip_id         varchar(20),
vehicle_current_status  integer,
record_timestamp varchar(100)
);