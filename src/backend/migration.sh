#!/usr/bin/env bash
cd src/backend/GMBAcademy.Web/

echo "Migration name?"
read migration
if  [[ ! -z $migration ]] 
    then 
        context=DataContext
        dotnet ef migrations add $migration -c $context  --project ../GMBAcademy.DataAccess.Migrations
        dotnet ef database update -c $context
read migration
fi
