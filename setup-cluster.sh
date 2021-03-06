#! /bin/bash

#This assumes you have maprcli and access to /public_data

#set up volumes
maprcli volume create -name demo-files -path /demo-files -readAce 'p' -writeAce 'p'
maprcli volume create -name demo-tables -path /demo-tables -readAce 'p' -writeAce 'p'
maprcli volume create -name demo-streams -path /demo-streams -readAce 'p' -writeAce 'p'

#Set up tables, etc
# Set up DB tables demo bits

#Create three tables we'll load later
maprcli table create -path /demo-tables/business -tabletype json
maprcli table create -path /demo-tables/user -tabletype json

#Copy public_data source files for our tables
hadoop fs -copyFromLocal /public_data/common_datasets/yelp/dataset/business.json /demo-files/ 
hadoop fs -copyFromLocal /public_data/common_datasets/yelp/dataset/user.json /demo-files/ 

#load data from public_data
mapr importJSON -idField business_id -src /demo-files/business.json -dst /demo-tables/business -mapreduce false
mapr importJSON -idField user_id -src /demo-files/user.json -dst /demo-tables/user -mapreduce false 
