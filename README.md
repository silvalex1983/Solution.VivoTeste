Vivo – BOT API

Engenharia de Software: Analisando o problema no domínio Bot Api, Pensei no desenvolvimento de 2 microsserviços ( Shared-database-per-service pattern : https://docs.aws.amazon.com/prescriptive-guidance/latest/modernization-data-persistence/shared-database.html ) para a plataforma .O microsservico Bot para manutenção dos Robos e o Microsserviço Message para troca de mensagens com os usuários.
Decidi pela organização dos microsserviços utilizando o estilo arquitetural Hexagonal, que tem por finalidade encapsular a camada de domínio, possibilitando a comunicação com o “mundo exterior” através da implementação das portas e adaptadores, possibilitando que o domínio da solução seja agnóstico a tecnologia, ou seja, independente de tecnologias de front end e camadas de persistência.

Tecnologias: Para o desenvolvimento dos microsserviços, fiz a utilização da linguagem c# e framework .Net Core 3.1. Trata-se de uma tecnologia robusta e multiplataforma para desenvolvimento de sistemas e apis rest e também facilita a utilização do docker para “contenirização” da aplicação. Para persistência dos dados utilizamos o banco de dados SQL Server que tem fácil integração com a plataforma .Net. 

Infraestrutura: No que se refere a infraestrutura, fiz a escolha do provedor de cloud AWS. Para execução da api, utilizaremos o ECS (Elastic Container Service), pois oferece a capacidade de executar containers e tem a possibilidade de configurar o serviço no contexto serverless através da utilização do serviço Fargate O conjunto disponibiliza de um application  load balance para distribuição da carga, além do auto scaling disponibilizado pelo próprio serviço de container (ECS) proporcionando que os recursos (EC2) sejam escalados horizontalmente  conforme a demanda ( elasticidade ). Para garantir a alta disponibilidade, os serviços foram configurados em duas zonas de disponibilidade distintas.

Deploy: Para deploy da aplicação, projetou-se uma esteira AWS. Utilizando os serviços da Pipeline da provedora de Cloud. O processo inicia-se com um commit do dockerfile no git e após o processo de build a imagem é registrada no ECR e gerado um buildspec.yml que gera uma nova taskdefinition que atualiza o serviço do ECS.

A arquitetura de infra projetada pode ser vista no desenho abaixo:

  

Execução em localhost: Acessar managment studio da máquina e executar o seguinte as seguintes instruções SQL.

CREATE DATABASE [vivo]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [vivo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [vivo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [vivo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [vivo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [vivo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [vivo] SET ARITHABORT OFF 
GO
ALTER DATABASE [vivo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [vivo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [vivo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [vivo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [vivo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [vivo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [vivo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [vivo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [vivo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [vivo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [vivo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [vivo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [vivo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [vivo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [vivo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [vivo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [vivo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [vivo] SET RECOVERY FULL 
GO
ALTER DATABASE [vivo] SET  MULTI_USER 
GO
ALTER DATABASE [vivo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [vivo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [vivo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [vivo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [vivo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [vivo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [vivo] SET QUERY_STORE = OFF
GO
ALTER DATABASE [vivo] SET  READ_WRITE 
GO
USE [vivo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bot](
	[Id] [uniqueidentifier] NOT NULL primary key,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
USE [vivo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[id] [uniqueidentifier] primary key not null,
	[ConversationId] [uniqueidentifier] not null,
	[TimeStamp] [datetime2](7) not null,
	[From] [uniqueidentifier] not null,
	[To] [uniqueidentifier] not null,
	[Text] [varchar](250) not null
) ON [PRIMARY]
GO



Acessar o arquivo appsettings.json no projeto de cada um dos microsserviços e alterar a string de conexão com os dados de servidor local.

Implementei a Swagger nas APIs para documentação e testes. Entretanto, as chamadas as apis podem ser realizadas através do Postman.

