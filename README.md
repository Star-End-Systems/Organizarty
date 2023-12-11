# Organizarty

## Link da apresentação: https://www.youtube.com/watch?v=tWpAWlQtNZc

## Dependências

- dotnet ef. [Download](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [Docker](https://docs.docker.com/get-docker/) e [Docker composer](https://docs.docker.com/compose/install/) (opcionais)
- [Dotnet Core v7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).
- Configurações do [Mailgun](https://www.mailgun.com/).
- Configurações do [Supabase](https://supabase.com/).
- [Node JS v20.5.1 ou superior](https://nodejs.org/en).

## Rodar 

### Get the code
- Clone repo
```sh
git clone https://github.com/Star-End-Systems/Organizarty
```

### Start database

- Inicie o banco de dados
- - Caso esteja usando docker, inicie o container no arquivo `docker-compose.yml`
- - Caso não esteja usando o docker, configure a Connection string no arquivo `.env` localizado em `Organizarty.UI/.env`. Veja detalhes nas próximas sessões.

- Rode as Migrations (Após o banco devidamente configurado no passo anterior)
```sh
dotnet ef database update  -s Organizarty.UI
```

### Environment

- Configure serviços nas variáveis de ambiente. 

- 1. A aplicação depende de serviços externos para total funcionamento, como enviar Emails ou Upload de imagens. 
- 2. Crie um arquivo chamado `.env` no diretório `Organizarty.UI` ao lado do arquivo já existente `.env.example`.
- 3. Copie o conteúdo do arquivo de exemplo para o recem criado. Agora, altere as informações se pautando em dados válidos.

A seguir, um detalhe referente ao preenchimento das variáveis:

```
DATABASE_CONNECTION_STRING="String de conexão, opcional caso use o banco no docker"
JWY_SECRET_KEY="Uma chave aleatória, para criptografar o token de usuário."
MAILGUN_API_KEY="API KEY da plataforma Mailgun
EMAILSENDER_DOMAIN= o domínio pelo qual será enviado o email, use o disponibilizado pela plataforma Mailgun."
EMAILSENDER_DISPLAY_NAME="Nome de exibição do Autor do Email"
EMAILSENDER_FROM="Mesmo que EMAILSENDER_DOMAIN"
EMAILSENDER_REPLYTO="Mesmo que EMAILSENDER_DOMAIN"
APPLICATION_CONFIRM_ENDPOINT="URL da aplicação responsável por confirmar o código do Email, usado no corpo do Email enviado"
SUPABASE_TOKEN="API KEY do Bucket da plataforma Supabase"
SUPABASE_APPLICATION_ID="Id da aplicaçaõ Supabase"
```

> Todas as informações sobre chaves podem ser encontradas facilmente dentro das plataformas usadas. Caso não sejam preenchidos, a aplicação não funcionará corretamente e irá fechar.

### Setup Assets

Dentro do diretório `Organizarty.UI`(de `cd` para lá) devemos compilar os arquivos referentes ao frontend da aplicação, 

- Instalar dependências do Node
```sh
npm i
```

- Compilar arquvio do Tailwind
```sh
npm run buildcss:dev
```
### Run

Para finalmente rodar o projeto, execute um dos seguites comandos:

- Caso esteja no Root da aplicação (fora de qualquer diretório de  classlib)
```sh
dotnet watch run --project Organizarty.UI
```

- Caso dentro da classlib `Organizarty.UI`:
```sh
dotnet watch run
```

- Abra o projeto em `localhost:8000`
