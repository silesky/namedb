#! /usr/bin/env bash
rm -rf Migrations/*
psql -t myndb -c "select 'drop table \"' || tablename || '\" cascade;' from pg_tables where schemaname = 'public'" | psql myndb
dotnet ef migrations add `date +%Y-%m-%d:%H:%M:%S` && echo "migration complete!"
dotnet ef database update && echo "database updated!"
dotnet build