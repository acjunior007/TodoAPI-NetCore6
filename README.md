Não será necessário criar o banco de dados, ao iniciar o projeto API ou o projeto de teste, já será criado automaticamente.

Mudar a string de conexão do banco de dados, para o que você estiver usando, que se encontra no arquivo appsetting.json no projeto TodoListAPP.
"conn": "Server=seuServer;Database=TodoListAPP_Teste;Trusted_Connection=True;"

Caso queira usar com usando o Docker, adicionei um arquivo chamado 'docker-compose.yml', basta usar o comando 
'docker-compose up -d'
Assim que subir o servico no docker, precisa tambem mudar a string de conexao no arquivo appsetting.json no projeto TodoListAPP.
"conn": "Server=localhost,1433;Database=TodoListAPP_Teste;User Id=SA;Password=Todo@1234;TrustServerCertificate=True;"
