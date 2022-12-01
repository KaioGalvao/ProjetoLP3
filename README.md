# Projeto LP3

Para Criar as Tabelas:

```
CREATE TABLE IF NOT EXISTS Clientes(
	codigo int not null primary key,
	nome varchar(100) not null,
	cpf varchar(100) not null,
    idade int not null,
    endereco varchar(100) not null
);
```

```
CREATE TABLE IF NOT EXISTS Vendedores(
	codigo int not null primary key,
	nome varchar(100) not null
);
```

```
CREATE TABLE IF NOT EXISTS Carros(
	codigo int not null primary key,
	marca varchar(100) not null,
    modelo varchar(100) not null,
    cor varchar(100) not null
);
```

```
CREATE TABLE IF NOT EXISTS Motos(
	codigo int not null primary key,
	marca varchar(100) not null,
    modelo varchar(100) not null,
    cor varchar(100) not null
);
```

```
CREATE TABLE IF NOT EXISTS Rodas(
	codigo int not null primary key,
	aro int not null
);
```

```
CREATE TABLE IF NOT EXISTS Pecas(
	codigo int not null primary key,
	nome varchar(100) not null
);

```



