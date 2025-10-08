[README_Diagon_Alley.md](https://github.com/user-attachments/files/22771286/README_Diagon_Alley.md)
# 🧙‍♂️ Diagon Alley – Text-Based Store Simulator  

### 📖 About the Project  
This project was developed as part of **Programming Lab 2**, where the goal was to build a **simple console-based store application**.  

My version, called **Diagon Alley**, is inspired by the magical world where wizards buy their supplies.  
Players can register as new customers or log in to existing ones, then explore a fully interactive shopping experience.  

Once logged in, the user can:  
- 🛍️ Shop for magical products  
- 🧺 View their cart  
- 💰 Proceed to checkout  
- 💱 Change currency (e.g., SEK, USD, EUR)  
- 🚪 Log out  

Each customer has a **membership level** (Bronze, Silver, or Gold) that grants different discounts.  
All registered users are stored in a file and can log in again later.  

---

### ✅ Assignment Requirements  

The project fulfills all requirements stated in the Lab 2 specification:

#### 1. **Variables and Classes**
- Classes for **Customer (Wizard)** and **Product**.  
- Each customer has a name, password, shopping cart, and membership level.  
- Each product has a name, price, and currency.  

#### 2. **Conditions and Loops**
- Menu navigation uses `if`/`switch` statements.  
- Main program loop keeps running until the user exits.  
- Login system allows multiple password attempts.  

#### 3. **Object-Oriented Design (Inheritance)**
- `Wizard` is the base class.  
- `BronzeWizard`, `SilverWizard`, and `GoldWizard` inherit from it and apply different discounts:  
  - 🥇 **Gold:** 15% off total  
  - 🥈 **Silver:** 10% off total  
  - 🥉 **Bronze:** 5% off total  

#### 4. **Methods**
Key methods include:  
- `CheckPassword()` – verifies the entered password.  
- `AddToCart()` – adds a product to the cart.  
- `GetTotalPrice()` – calculates the total cost including discounts.  
- `ChangeCurrency()` – changes all displayed prices to another currency.  
- `ToString()` – returns formatted customer info and cart contents.  

#### 5. **File Handling**
- Customer data is stored in a text file so that registered users remain available between runs.  

#### 6. **Currency Handling**
- Prices can be displayed in multiple currencies (SEK, USD, EUR, etc.).  

---

### 🛠️ Recommended Development Steps
1. Create base classes for **Customer/Wizard** and **Product**.  
2. Implement menus for **registration**, **login**, and **store navigation**.  
3. Add logic for **shopping**, **viewing cart**, and **checkout**.  
4. Save customer data to a file.  
5. Implement **currency switching**.  
6. Add **discount levels via inheritance**.  

---

### 🏆 Grading Criteria  

#### Pass (G)
- Program works as described.  
- Correct total price and item counts in the cart.  
- `ToString()` implemented.  
- Login works for at least three predefined users.  
- No crashes or infinite loops.  

#### Pass with Distinction (VG)
- Code is well-structured and easy to follow.  
- No unnecessary repetition.  
- Scalable and easy to extend.  
- Extra features implemented:
  - 🪄 Membership levels (Gold/Silver/Bronze)  
  - 💾 File-based customer storage  
  - 💱 Multi-currency support  

---

### 🚧 Project Status
**Diagon Alley** is fully functional and meets all grading criteria.  
Further features (like persistent carts and visual enhancements) can easily be added in future updates.  

---


