#Consul Dotnet Webapi Sample

SHELL := /bin/bash

.PHONY: clean copy-config consul

clean:
	rm -f ${PWD}/consul/config/consul-test-config.json
	rm -rf ${PWD}/consul/data/*

copy-config:
	cp ${PWD}/cd/consul-test-config.json ${PWD}/consul/config/

consul: clean
	docker run -d --name=consul-server \
	-p 8500:8500 \
	-v ${PWD}/consul/data:/consul/data \
	-e CONSUL_BIND_INTERFACE=eth0 \
	consul agent -dev -ui -client=0.0.0.0
