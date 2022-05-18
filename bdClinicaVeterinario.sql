create database bdClinicaVeterinaria;
use bdClinicaVeterinaria;

create table tbTipoUsuario(
	codTipoUsuario int primary key auto_increment,
    usuario varchar(50)
);

insert into tbTipoUsuario values(default,'admin'),
(default,'comum');
-- ****************************************************************************************************

create table tbLogin(
	usuario varchar(50) primary key,
    senha varchar(10),
    codTipoUsuario int,
    foreign key (codTipoUsuario) references tbTipoUsuario(codTipoUsuario)	
);

insert into tbLogin values ('Rovilson','123456',1),
('Maria','123456',2);
--  *************************************************************************************************************
create table tbCliente(
	codCliente int primary key auto_increment,
    nomeCliente varchar (50),
    telefoneCliente varchar(50),
    EmailCliente varchar(50)
    );
    
    create table tbTipoAnimal(
		codTipoAnimal int primary key auto_increment,
        tipoAnimal varchar(50)
    );
    
    create table tbAnimal(
		codAnimal int primary key auto_increment,
        nomeAnimal varchar(50),
        codTipoAnimal int,
        codCliente int,
        foreign key (codTipoAnimal) references tbTipoAnimal (codTipoAnimal),
        foreign key (codCliente) references tbCliente (codCliente)
    );
    
    create table tbVeterinario(
		codVet int primary key auto_increment,
        nomeVet varchar(50)    
    );
    
    create table tbAtendimento(
		codAtendimento int primary key auto_increment,
		DataAtendimento varchar(20),
		HoraAtendimento varchar(8),
		codAnimal int,
		codVet int,
        foreign key (codAnimal) references tbAnimal (codAnimal),
        foreign key (codVet) references tbVeterinario (codVet)
    );