CREATE TABLE Stream (
	id SERIAL UNIQUE NOT NULL,
	nome VARCHAR(50)  NOT NULL,
	
	CONSTRAINT pk_Stream PRIMARY KEY (id)
);

CREATE TABLE Atividades (
	id SERIAL UNIQUE NOT NULL,
	nome VARCHAR(50)  NOT NULL,
	fk_stream INTEGER,
	
	CONSTRAINT pk_Atividades PRIMARY KEY (id),
	FOREIGN KEY (fk_stream) REFERENCES stream(id)
);

CREATE TABLE fase (
	id SERIAL UNIQUE NOT NULL,
	nome VARCHAR(50)  NOT NULL,
	
	CONSTRAINT pk_fase PRIMARY KEY (id)
);


CREATE TABLE Apontamentos (
	id SERIAL UNIQUE NOT NULL,
	data_atividade DATE NOT NULL,
	horasTrabalhada INTEGER NOT NULL,
	observacao VARCHAR(150),

	fk_atividades INTEGER NOT NULL,
	fk_stream INTEGER NOT NULL,
	fk_fase INTEGER NOT NULL,
	
	CONSTRAINT pk_apontamentos PRIMARY KEY (id),

	FOREIGN KEY (fk_atividades) REFERENCES atividades(id),
	FOREIGN KEY (fk_stream) REFERENCES stream(id),
	FOREIGN KEY (fk_fase) REFERENCES fase(id)
);
