#ifndef SINGLELIST_H
#define SINGLELIST_H

template <class T>
class SingleList {
   private:
    struct Node {
        T data;
        Node *next;
        Node(T data, Node* next) : data(data), next(next){}
    };
    Node *head;

   public:
    SingleList();
    SingleList(const SingleList &);
    SingleList(T);
    ~SingleList();
    void insert_back(T);
    void insert_front(T);
    void insert_at(T, int);
    void delete_at(int);
    void display();
    bool empty();
    void reverse();
    T pop_back();
    T pop_front();
    bool operator==(const SingleList &) const;
    SingleList &operator=(const SingleList &);
};
#include "SingleList.cpp"
#endif