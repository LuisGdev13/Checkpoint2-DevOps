CREATE TABLE Clientes
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NULL,
    Telefone NVARCHAR(30) NULL,

    CONSTRAINT PK_Clientes
        PRIMARY KEY (Id)
);

CREATE TABLE Transacoes
(
    Id INT IDENTITY(1,1) NOT NULL,
    Descricao NVARCHAR(200) NOT NULL,
    Valor DECIMAL(18,2) NOT NULL,
    Tipo NVARCHAR(20) NOT NULL,
    Data DATETIME2 NOT NULL,
    ClienteId INT NOT NULL,

    CONSTRAINT PK_Transacoes
        PRIMARY KEY (Id),

    CONSTRAINT FK_Transacoes_Clientes
        FOREIGN KEY (ClienteId)
        REFERENCES Clientes(Id)
        ON DELETE NO ACTION
);
