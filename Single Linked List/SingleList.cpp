#include "SingleList.h"

#include <iostream>
using namespace std;

template <class T>
SingleList<T>::SingleList() {
    head = nullptr;
}

template <class T>
SingleList<T>::SingleList(const SingleList<T> &list) {
    Node *temp = list.head;
    while (temp) {
        insert(temp->data);
        temp = temp->next;
    }
}

template <class T>
SingleList<T>::SingleList(T data) {
    head = nullptr;
    insert(data);
}

template <class T>
SingleList<T>::~SingleList() {
    if(!head) return;
    Node *temp = head;
    while (temp) {
        Node *curr = temp;
        temp = temp->next;
        delete curr;
    }
    head = nullptr;
}

template <class T>
void SingleList<T>::insert(T data) {
    Node *newNode = new Node(data, nullptr);
    if (!head) {
        head = newNode;
    } else {
        Node *temp = head;
        while (temp->next != nullptr) {
            temp = temp->next;
        }
        temp->next = newNode;
    }
}

template <class T>
void SingleList<T>::display() {
    if (!head) {
        cout << "Empty";
    }
    Node *current = head;
    while (current) {
        cout << current->data << " ";
        current = current->next;
    }
    delete current;
}

template<class T>
bool SingleList<T>::empty(){
    return !head;
}

template <class T>
T SingleList<T>::pop_back() {
    if (!head) {
        throw out_of_range("List is empty");
    }
    if (!head->next) {
        T data = head->data;
        delete head;
        head = nullptr;
        return data;
    }
    Node *current = this->head;
    while (current->next->next) {
        current = current->next;
    }
    T data = current->next->data;
    delete current->next;
    current->next = nullptr;
    return data;
}

template <class T>
T SingleList<T>::pop_front() {
    if (!head) {
        throw out_of_range("List is empty");
    }
    if (!head->next) {
        T data = head->data;
        delete head;
        head = nullptr;
        return data;
    }
    Node* temp = head;
    T data = head->data;
    head = head->next;
    delete temp;
    return data;
}

template <class T>
bool SingleList<T>::operator==(const SingleList<T> &other) const {
    Node *list1_pointer = head, *list2_pointer = other.head;
    while (list1_pointer && list2_pointer) {
        if (list1_pointer->data != list2_pointer->data) return false;
        list1_pointer = list1_pointer->next;
        list2_pointer = list2_pointer->next;
    }
    delete list1_pointer;
    delete list2_pointer;
    return true;
}

template <class T>
SingleList<T> &SingleList<T>::operator=(const SingleList<T> &other) {
    if (this != &other) {
        Node *current = head;
        while (current) {
            Node *temp = current;
            current = current->next;
            delete temp;
        }
        head = nullptr;

        Node *temp = other.head;
        while (temp) {
            insert(temp->data);
            temp = temp->next;
        }
    }
    return *this;
}

