# Solicitação de Material 📋

## 🚧 Status do Projeto

O projeto está em desenvolvimento contínuo.  
Atualmente, estou focado em implementar funcionalidades básicas e melhorar a escalabilidade.  

Se você encontrar algum problema ou quiser sugerir melhorias, sinta-se à vontade para abrir uma issue ou contribuir diretamente!  

## 📖 Sobre o projeto
O projeto **Solicitação de Material** é uma API desenvolvida em **ASP.NET Core** que gerencia processos relacionados a funcionários,
equipes e materiais em uma organização. Ele permite a criação, consulta, atualização e exclusão de registros, 
além de estabelecer relacionamentos entre diferentes entidades, como equipes e funcionários.

## 🚀 Funcionalidades
- **Funcionários**  
  - Cadastro, consulta, atualização e exclusão de funcionários.
- **Materiais**  
  - Gerenciamento de materiais, incluindo cadastro, consulta, atualização e exclusão.
- **Equipes**  
  - Criação, consulta e exclusão de equipes.
- **Relacionamentos**  
  - Associação de funcionários a equipes.
  - Solicitação de materiais por equipes.

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** Entity Framework Core com suporte a MySQL
- **Padrões:** Programação Orientada a Objetos (POO), Repositório e Injeção de Dependência
- **Bibliotecas:** Pomelo.EntityFrameworkCore.MySql

## 📂 Estrutura do Projeto
- **Controllers:** Controladores para gerenciar requisições HTTP.  
  - `EmployeeController`
  - `MaterialController`
  - `TeamController`
  - `RelationShipEquipeFuncionarioController`
- **Models:** Classes que representam as entidades do sistema.  
  - `Equipe`
  - `Funcionario`
  - `Material`
  - `RequisicaoDeMaterial`
  - `MateriaisSolicitados`
- **Services:** Camada de lógica de negócios para abstrair as operações realizadas pelos controladores.
- **DTOs:** Objetos de transferência de dados para simplificar e padronizar as requisições e respostas.

## 📋 Estrutura de Dados
- **Funcionário:** Gerencia informações como nome e matrícula.  
- **Equipe:** Contém prefixo e relacionamento com funcionários.  
- **Material:** Inclui detalhes como nome, descrição, quantidade e status.  
- **Requisição de Material:** Relaciona uma equipe e materiais solicitados.  
- **Relacionamento Equipe-Funcionário:** Define associações entre funcionários e equipes.


## 🔧 Melhorias Futuras

- [ ] Adicionar autenticação e autorização.
- [ ] Implementar paginação nos endpoints de listagem.
- [ ] Criar testes unitários para aumentar a confiabilidade do sistema.
- [ ] Melhorar o gerenciamento de logs e erros.

