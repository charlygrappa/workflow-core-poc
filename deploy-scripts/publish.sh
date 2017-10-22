#!/bin/bash

OWD=$PWD
cd ..
TAG=$1
if [ -z $TAG ] 
	then
	echo "El tag es obligatorio"
	exit 1
fi

echo "Generando version $TAG"
# Usar dotnet publish y generar un release a la carpeta temp
dotnet publish -o $PWD/releases/$TAG
# zipear el directorio
cd $PWD/releases
zip -r -X $TAG.zip $TAG
rm -rf ./$TAG

# Volver al principio
cd $OWD

