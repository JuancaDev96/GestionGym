
CREATE TABLE Puesto (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

CREATE TABLE Colaborador (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(100),
    IdPuesto INT NOT NULL,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_Colaborador_Puesto FOREIGN KEY (IdPuesto) REFERENCES Puesto(Id)
);

CREATE TABLE ColaboradorUsuario (
    Id SERIAL PRIMARY KEY,
    IdColaborador INT NOT NULL,
    Usuario VARCHAR(50),
    Clave VARCHAR(50),
    BloqueadoHasta TIMESTAMP,
    UltimoBloqueo TIMESTAMP,
    IntentosFallidos INT,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_ColaboradorUsuario_Colaborador FOREIGN KEY (IdColaborador) REFERENCES Colaborador(Id)
);

CREATE TABLE Permiso (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

CREATE TABLE ColaboradorUsuarioPermiso (
    Id SERIAL PRIMARY KEY,
    IdColaboradorUsuario INT NOT NULL,
    IdPermiso INT NOT NULL,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_ColaboradorUsuarioPermiso_ColaboradorUsuario FOREIGN KEY (IdColaboradorUsuario) REFERENCES ColaboradorUsuario(Id),
    CONSTRAINT FK_ColaboradorUsuarioPermiso_Permiso FOREIGN KEY (IdPermiso) REFERENCES Permiso(Id)
);


CREATE TABLE Cliente (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    DNI VARCHAR(12),
    Celular VARCHAR(9),
    Correo VARCHAR(150),
    FechaNacimiento DATE,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

-- Tabla Maestro
CREATE TABLE Maestro (
    Id SERIAL PRIMARY KEY,
    Codigo VARCHAR(30) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

-- Tabla MaestroDetalle
CREATE TABLE MaestroDetalle (
    Id SERIAL PRIMARY KEY,
    IdMaestro INT NOT NULL,
    Codigo VARCHAR(30) NOT NULL,
    Valor VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(200),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_MaestroDetalle_Maestro FOREIGN KEY (IdMaestro) REFERENCES Maestro(Id)
);

-- Tabla ControlFisico_Cliente
CREATE TABLE ControlFisico_Cliente (
    Id SERIAL PRIMARY KEY,
    IdParametro INT NOT NULL,
    IdCliente INT NOT NULL,
    Valor VARCHAR(30),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_ControlFisico_Cliente_MaestroDetalle FOREIGN KEY (IdParametro) REFERENCES MaestroDetalle(Id),
    CONSTRAINT FK_ControlFisico_Cliente_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
);

-- Tabla HistorialMedico_Cliente
CREATE TABLE HistorialMedico_Cliente (
    Id SERIAL PRIMARY KEY,
    IdParametro INT NOT NULL,
    IdCliente INT NOT NULL,
    Valor VARCHAR(30),
    Recomendacion VARCHAR(100),
    Consideracion VARCHAR(100),
    Comentario VARCHAR(100),
   Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_HistorialMedico_Cliente_MaestroDetalle FOREIGN KEY (IdParametro) REFERENCES MaestroDetalle(Id),
    CONSTRAINT FK_HistorialMedico_Cliente_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
);

-- Tabla ControlAvance_Cliente
--esta tabla me va a permitir registrar el avance del cliente, registrar peso, medidas, kg de levantamiento, etc 
CREATE TABLE ControlAvance_Cliente (
    Id SERIAL PRIMARY KEY,
    IdParametro INT NOT NULL,
    IdCliente INT NOT NULL,
    Valor VARCHAR(30),
   Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_ControlAvance_Cliente_MaestroDetalle FOREIGN KEY (IdParametro) REFERENCES MaestroDetalle(Id),
    CONSTRAINT FK_ControlAvance_Cliente_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
);

-- Tabla InformeInstructor
-- esta tabla me va a permitir registrar informes del avance del instructor, una bitacora
CREATE TABLE InformeInstructor (
    Id SERIAL PRIMARY KEY,
    IdInstructor INT NOT NULL,
    IdCliente INT NOT NULL,
    Consideracion VARCHAR(300),
    Comentario VARCHAR(300),
    Nivel INT,
  	Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_InformeInstructor_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
    CONSTRAINT FK_InformeInstructor_Instructor FOREIGN KEY (IdInstructor) REFERENCES Colaborador(Id)
);


CREATE TABLE Ejercicio (
    Id SERIAL PRIMARY KEY,
    IdGrupoMuscular_Parametro INT not null,
    Nombre VARCHAR(50),
    Descripcion VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_AplicacionEjercicio_GrupoMuscular FOREIGN KEY (IdGrupoMuscular_Parametro) REFERENCES maestrodetalle(Id) 
);

CREATE TABLE AplicacionEjercicio (
    Id SERIAL PRIMARY KEY,
    IdEjercicio INT not null,
    IdAplicacion_Parametro INT not null,
   	Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_AplicacionEjercicio_Ejercicio FOREIGN KEY (IdEjercicio) REFERENCES Ejercicio(Id), 
    CONSTRAINT FK_AplicacionEjercicio_Aplicacion FOREIGN KEY (IdAplicacion_Parametro) REFERENCES maestrodetalle(Id) 
);

CREATE TABLE RutinaEjercicio (
    Id SERIAL PRIMARY KEY,
    IdEjercicio INT not null,
    Descripcion varchar(150) not null,
    Repeticiones int not null,
    Series int not null,
   	Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_RutinaEjercicio_Ejercicio FOREIGN KEY (IdEjercicio) REFERENCES Ejercicio(Id)
);

--esta tabla va a tener la ruta de los recursos como imagenes, videos, etc
CREATE TABLE RecursosEjercicio (
    Id SERIAL PRIMARY KEY,
    IdEjercicio INT not null,
    Ruta varchar(200) not null,
   	Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_RecursosEjercicio_Ejercicio FOREIGN KEY (IdEjercicio) REFERENCES Ejercicio(Id)
);
CREATE TABLE Maquina (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50) not null,
    Descripcion VARCHAR(150) not null,
    IdGrupoMuscular_Parametro int not null,
    Ubicacion varchar(100) null,
    IdEstadoMaquina_Parametro int not null,
    RequiereSupervision boolean,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_Maquina_GrupoMuscular FOREIGN KEY (IdGrupoMuscular_Parametro) REFERENCES maestrodetalle(Id),
    CONSTRAINT FK_Maquina_EstadoMaquina  FOREIGN KEY (IdEstadoMaquina_Parametro) REFERENCES maestrodetalle(Id) 
);


CREATE TABLE MaquinaEjercicio (
    Id SERIAL PRIMARY KEY,
    IdMaquina int not null,
    IdEjercicio int not null,
    EsMaquina boolean,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_MaquinaEjercicio_Maquina FOREIGN KEY (IdMaquina) REFERENCES Maquina(Id),
    CONSTRAINT FK_MaquinaEjercicio_Ejercicio  FOREIGN KEY (IdEjercicio) REFERENCES Ejercicio(Id) 
);

CREATE TABLE FichaCliente (
    Id SERIAL PRIMARY KEY,
    IdCliente INT not null,
    FechaInicio TIMESTAMP,
    Objetivo VARCHAR(150),
    Nivel INT,
    IdEstadoActual_Parametro INT not null,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_FichaCliente_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
    CONSTRAINT FK_AplicacionEjercicio_EstadoActual  FOREIGN KEY (IdEstadoActual_Parametro) REFERENCES maestrodetalle(Id) 
);


CREATE TABLE RutinaCliente (
    Id SERIAL PRIMARY KEY,
    IdCliente INT not null,
    Dia INT not null,
    comentario VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_RutinaCliente_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
);

CREATE TABLE RutinaCliente_Detalle (
    Id SERIAL PRIMARY KEY,
    IdRutina int not null,
    IdEjercicio INT not null,
    Repeticiones INT not null,
    IdTipoRutina_Parametro int not null,--define si es estiramiento, calentamiento, rutina o cardio
    Series INT not null,
    DescansoMinutos INT not null,
    comentario VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_RutinaCliente_Detalle_Cliente FOREIGN KEY (IdRutina) REFERENCES RutinaCliente(Id),
    CONSTRAINT FK_RutinaCliente_Detalle_TipoRutina  FOREIGN KEY (IdTipoRutina_Parametro) REFERENCES maestrodetalle(Id) 
);

CREATE TABLE Suscripcion (
    Id SERIAL PRIMARY KEY,
    IdCliente int not null,
    Descripcion VARCHAR(150) not null,
    IdTipoSuscripcion_Parametro int not null,
    IdEstadoSuscripcion_Parametro int not null,--define si es libre o por mensualidad
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_Suscripcion_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
    CONSTRAINT FK_Suscripcion_EstadoSuscripcion  FOREIGN KEY (IdEstadoSuscripcion_Parametro) REFERENCES maestrodetalle(Id),
    CONSTRAINT FK_Suscripcion_TipoSuscripcion  FOREIGN KEY (IdTipoSuscripcion_Parametro) REFERENCES maestrodetalle(Id) 
);

create table Caja(
 	Id SERIAL PRIMARY KEY,
    Nombre varchar(50) not null,
    Descripcion varchar(100) not null,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

create table MovimientoCaja(
 	Id SERIAL PRIMARY KEY,
 	IdCaja int not null,
    IdCliente int not null,
    EsIngreso boolean not null,
    Concepto varchar(100) not null,
    IdMedio_Parametro int not null,
    Monto DECIMAL not null,
    PagoCon DECIMAL null,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_IngresoCaja_IdCliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
    CONSTRAINT FK_IngresoCaja_Caja FOREIGN KEY (IdCaja) REFERENCES Caja(Id),
    CONSTRAINT FK_MovimientoCaja_Medio  FOREIGN KEY (IdMedio_Parametro) REFERENCES maestrodetalle(Id) 
);

CREATE TABLE SuscripcionDetalle (
    Id SERIAL PRIMARY KEY,
    IdSuscripcion int not null,
    IdMovimientoCaja int not null,
    FechaFijaPagada TIMESTAMP null,
    PeriodoInicioPagado TIMESTAMP null,
    PeriodoFinPagado TIMESTAMP null,
    Monto DECIMAL not null,
    PagoCon DECIMAL null,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_SuscripcionDetalle_Suscripcion FOREIGN KEY (IdSuscripcion) REFERENCES Suscripcion(Id),
    CONSTRAINT FK_SuscripcionDetalle_IngresoCaja FOREIGN KEY (IdMovimientoCaja) REFERENCES MovimientoCaja(Id)
);


