#!/bin/bash

# Defina as variáveis de conexão
SERVER="localhost:1433"  # ou o endereço do seu servidor SQL
USER="sa"
PASSWORD="SuperPassword@24"
DATABASE="master"  # Usamos "master" temporariamente para criar o banco de dados

# Caminho do arquivo SQL contendo os comandos para criar o banco de dados e a tabela
SQL_FILE="init.sql"  # Certifique-se de que este script esteja no mesmo diretório ou forneça o caminho correto

# Executa o comando sqlcmd para rodar o script SQL
/opt/mssql-tools/bin/sqlcmd -S $SERVER -U $USER -P $PASSWORD -d $DATABASE -i $SQL_FILE

# Verifica se o comando foi bem-sucedido
if [ $? -eq 0 ]; then
  echo "Script SQL executado com sucesso."
else
  echo "Falha na execução do script SQL."
fi
