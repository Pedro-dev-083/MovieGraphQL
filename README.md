
# MovieGraphQL

Componente de dados do Projeto chamado **"*Favorite Movies*"**, cujo o objetivo é poder guardar os filmes favoritos.

Esse projeto foi feito utilizando *C#*, com *.Net Core 8.0* sendo o *framework*, possuindo rotas para outro componente em formato ***GraphQL***, com um banco de dados ***SQLite***, e guardando os dados utilizando do *ORM **Entity Framework*** .

Esse é um projeto feito por **Pedro Souza de Azevedo** como *MVP* para a disciplina de **Arquitetura de Software**, do curso de pós-graduação da ***PUC-Rio***.

O componente da API REST desse projeto está aqui: https://github.com/Pedro-dev-083/api-favorite-movies

## Como configurar o projeto

### Clonagem do projeto:

Para clonar o projeto em sua máquina, é necessário ter o ***Git*** instalado, e então, você pode usar o seguinte comando:  

    git clone https://github.com/Pedro-dev-083/MovieGraphQL.git

Logo após ao clonar, você pode abrir a pasta, e acessar o terminal dentro dela para seguir os próximos passos.

### Dependência de dados:

O projeto utiliza de um componente externo encontrado nesse repositório: .
É necessário esse componente externo estar instalado na máquina via ***Docker*** para o perfeito funcionamento desse projeto.

### Uso do *Docker*:

#### Instalação do *Docker*:
Quanto a execução do projeto, é necessário ter apenas o ***Docker*** instalado na sua máquina, que, caso não tenha, você pode seguir a documentação deles para poder instalar e utilizar em sua máquina.
Link para a documentação de ***Docker***: https://www.docker.com/

#### Ativar o *Docker*:
Para instalar o projeto em sua máquina é necessário primeiro ativar o *Docker*.
##### *Windows* e *Mac*:
Para *Windows* e *Mac*, você pode apenas abrindo o ***Docker Desktop***.
##### *Linux*:
Para *Linux*, você precisa rodar o seguinte comando no **Terminal**:

    sudo systemctl start docker

### Instalação e Execução do Projeto:
Logo após ativar o *Docker*, você deve abrir o terminal do seu sistema operacional na raiz do projeto, onde está localizado o ***Dockerfile***. Depois de estar aberto, você deve utilizar o seguinte comando para montar a imagem do projeto.

    docker build -t movie-graphql .

Em primeira instância é normal demorar um pouco pois o projeto está sendo configurado pela primeira vez no seu *Docker*.
Após terminar de montar a imagem do projeto, você deve rodar o seguinte comando para montar o *container* a partir da imagem que foi criada:

    docker run -d -p 8080:8080 --name movie-graphql-container movie-graphql

Pronto, agora para garantir se o *container* foi criado e executado corretamente você pode executar um comando que verifica todos os *conteiners* ativos:

    docker ps

Caso tenha funcionado irá aparecer algo como:

    CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS          PORTS                                   NAMES
    422743df9199   movie-graphql   "dotnet MovieGraphQL…"   15 seconds ago   Up 14 seconds   6000-6001/tcp, 0.0.0.0:8080->8080/tcp   movie-graphql-container


  Depois, caso queira parar a execução do *container* você pode usar o seguinte comando:
  
    docker stop movie-graphql-container

E para ativar novamente, com o seguinte comando:

    docker start movie-graphql-container

Como o projeto foi montado pensando na porta 5000, você pode acessar com o *link* http://localhost:5000/ que irá para tela do *Swagger* com todas as rotas disponíveis.

### Comunicação entre containers
Com os dois containers ativos, você irá precisar criar uma rede *Docker* para poder seguir com o processo.
Para criar a rede é necessário o uso do comando:

    docker network create container-network
Logo após isso, precisará adicionar os dois containers a rede com os comandos:

    docker network connect container-network movie-graphql-container
    docker network connect container-network api-favorite-movies-container

## Utilizando o *Banana Cake Pop*

Esse projeto foi desenvolvido usando ***GraphQl***, tendo o *Banana Cake Pop* como documentação. Com o projeto aberto, você pode acessar o ***localhost*** mais a porta utilizada na construção, ou seja acessando o http://localhost:8080/ .

Lá você irá encontrar todos os *schemas* necessários para fazer consultas em ***GraphQL***.

## Considerações Finais

Esse projeto foi utilizado o *.Net Core 8.0*, que tem sido a tecnologia que mais estou trabalhando no momento, porém, decidi me desafiar e tentar usar o *GraphQL*, para entender seu funcionamento mais profundo.

A principio tive certas dificuldades de como iria comunicar entre containers com essa comunicação, mas depois de certas pesquisas, pude conseguir seguir com o desenvolvimento.

A questão da conteinerização foi um desafio maior do que eu imaginava no *.Net*, pois sempre estive acostumado com trabalhar apenas com o compilável dele. Houveram certas configurações que me fizeram ter muitas pesquisas pra poder entender, inclusive, o fato de ter uma documentação de *GraphQL*, pois confesso que foi bem difícil achar essa informação, mas depois de feito, foi satisfatório ver o resultado como um todo.
