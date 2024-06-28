cmake_minimum_required(VERSION 3.27)
project(Single_Linked_List)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)

add_executable(Single_Linked_List
        main.cpp
        SingleList.h)
