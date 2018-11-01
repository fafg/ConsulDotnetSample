#Consul Dotnet Webapi Sample

SHELL := /bin/bash

.PHONY: build test image

build:
	docker build -f 1.Dockerfile.Build ../

test:
	docker build -f 2.Dockerfile.Test ../

image:
	docker build -t $(image-name) -f 3.Dockerfile.Image ../

publish:
	@echo "TBD"