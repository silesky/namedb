#! /usr/bin/env bash
rm -rf Migrations/*
dotnet ef migrations add "initialMigration"
dotnet run
