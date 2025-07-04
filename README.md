#Fawry Internship Task

This project is a simple **console-based e-commerce system** built using **C#** as part of the technical challenge for the Fawry Quantum Internship.

---

# Features

- Define products with:
  - Name
  - Price
  - Quantity
  - Optional expiry (like cheese & biscuits)
  - Optional shipping (like TVs, with weight)
  
- Add products to a shopping cart
- Validate:
  - Product availability
  - Product expiration
  - Customer balance
- Checkout:
  - Calculate subtotal
  - Calculate shipping fee (30 EGP per kg)
  - Deduct from customer balance
  - Show shipping details (if applicable)

---

#Tech Stack

- Language: **C# (.NET 8.0)**
- Application Type: **Console Application**
- OOP Concepts: **Inheritance, Interfaces, Encapsulation, Polymorphism**
- SOLID Principles: Applied

---
# Sample Senario
**Input from user:**

Enter your name: Alaa
Enter your balance: 1000

Choose a product:

Cheese (expirable, shippable)

TV (shippable)

Scratch Card (non-expirable, non-shippable)

Enter product number: 1
Enter quantity: 2

Enter product number: 2
Enter quantity: 1

Enter product number: 3
Enter quantity: 1

Done? (yes): yes

**Output from program:**

Shipment notice
2x Cheese 200g
1x TV 500kg
Total package weight: 500.4kg

Checkout receipt
2x Cheese 200
1x TV 300
1x Scratch Card 50
Subtotal: 550
Shipping: 222
Amount: 772
Customer Balance: 228


