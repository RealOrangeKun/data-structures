#include "SingleList.h"
#include <iostream>
using namespace std;

int main() {
    SingleList<int> list;

    // Test insert_back
    list.insert_back(1);
    list.insert_back(2);
    list.insert_back(3);
    cout << "List after insert_back: ";
    list.display(); // Expected output: 1 2 3
    cout << endl;

    // Test insert_front
    list.insert_front(0);
    cout << "List after insert_front: ";
    list.display(); // Expected output: 0 1 2 3
    cout << endl;

    // Test insert_at
    list.insert_at(5, 2);
    cout << "List after insert_at position 2: ";
    list.display(); // Expected output: 0 1 5 2 3
    cout << endl;

    // Test delete_at
    list.delete_at(2);
    cout << "List after delete_at position 2: ";
    list.display(); // Expected output: 0 1 2 3
    cout << endl;

    // Test reverse
    list.reverse();
    cout << "List after reverse: ";
    list.display(); // Expected output: 3 2 1 0
    cout << endl;

    // Test pop_back
    int popBack = list.pop_back();
    cout << "Popped from back: " << popBack << endl; // Expected output: 3
    cout << "List after pop_back: ";
    list.display(); // Expected output: 2 1 0
    cout << endl;

    // Test pop_front
    int popFront = list.pop_front();
    cout << "Popped from front: " << popFront << endl; // Expected output: 2
    cout << "List after pop_front: ";
    list.display(); // Expected output: 1 0
    cout << endl;

    // Test empty
    cout << "Is list empty? " << (list.empty() ? "Yes" : "No") << endl; // Expected output: No

    // Test copy constructor
    SingleList<int> list2(list);
    cout << "Copied list using copy constructor: ";
    list2.display(); // Expected output: 1 0
    cout << endl;

    // Test assignment operator
    SingleList<int> list3;
    list3 = list;
    cout << "Copied list using assignment operator: ";
    list3.display(); // Expected output: 1 0
    cout << endl;

    // Test equality operator
    cout << "Are list and list2 equal? " << (list == list2 ? "Yes" : "No") << endl; // Expected output: Yes
    list.insert_back(4);
    cout << "Are list and list2 equal after modifying list2? " << (list == list2 ? "Yes" : "No") << endl; // Expected output: No

    return 0;
}
