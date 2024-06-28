#include "SingleList.h"
#include <iostream>

using namespace std;

int main() {
    // Test default constructor
    SingleList<int> list1;
    cout << "Is list1 empty: ";
    cout << list1.empty() << endl;

    // Test constructor with initial value
    SingleList<int> list2(10);
    cout << "List2 after constructor with initial value (10): ";
    list2.display();
    cout << endl;

    // Test copy constructor
    list1.insert(1);
    list1.insert(2);
    list1.insert(3);
    SingleList<int> list3(list1);
    cout << "List3 after copy constructor from List1: ";
    list3.display();
    cout << endl;


    // Test insert and display
    list1.insert(4);
    list1.insert(5);
    cout << "List1 after insertions: ";
    list1.display();
    cout << endl;

    // Test pop_back
    try {
        int popped_value = list1.pop_back();
        cout << "Popped value from back: " << popped_value << endl;
        cout << "List1 after pop_back: ";
        list1.display();
        cout << endl;
    } catch (const std::out_of_range& e) {
        std::cerr << "Exception caught: " << e.what() << endl;
    }

    // Test pop_front
    try {
        int popped_value = list1.pop_front();
        cout << "Popped value from front: " << popped_value << endl;
        cout << "List1 after pop_front: ";
        list1.display();
        cout << endl;
    } catch (const std::out_of_range& e) {
        std::cerr << "Exception caught: " << e.what() << endl;
    }

    // Test assignment operator
    SingleList<int> list5;
    list5 = list1;
    cout << "List5 after assignment from List1: ";
    list5.display();
    cout << endl;

    // Test operator==
    cout << "List1 equals List5? " << (list1 == list5) << endl;

    return 0;
}
