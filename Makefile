#Consul Dotnet Webapi Sample

SHELL := /bin/bash

.PHONY: clean copy-config consul

clean:
	rm -f ${PWD}/consul/config/consul-test-config.json
	sudo rm -rf ${PWD}/consul/data/*

copy-config:
	cp ${PWD}/cd/consul-test-config.json ${PWD}/consul/config/

consul: clean copy-config
	docker run -d --name consul-server -p 8500:8500 -p 8301:8301 \
	-v ${PWD}/consul/data:/consul/data \
	-v ${PWD}/consul/config:/consul/config \
	consul agent -server -ui \
	-client='{{ GetInterfaceIP "eth0" }}' \
	-bind='{{ GetInterfaceIP "eth0" }}' \

