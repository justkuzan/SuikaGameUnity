# 🌸 My Favorite Dacha

![My Favorite Dacha — gameplay screenshot](screenshot.png)

> **Suika style merge puzzle** with a focus on clean architecture high end UI and polished game feel.

**[▶ Play in Browser](https://cutecootgames.itch.io/dacha)**

---

## 🛠 Project Overview

This project is a high quality implementation of the Suika merge mechanic. The primary focus is on professional architecture and deep polish of the user experience.

---

## 🏗 Architectural Highlights

The project follows industry standards used in commercial game development to ensure scalability and code quality:

✅ **Scene Independent Entry Point**
The application uses the RuntimeInitializeOnLoadMethod attribute to initialize all global systems before the first scene loads. This ensures stable performance regardless of which level is used to start the game.

✅ **Centralized Service Management**
A Service Locator pattern allows game objects to access dependencies without tight coupling. This approach eliminates Inspector clutter and significantly simplifies code maintenance.

✅ **Event Driven Communication**
A global GameEvents bus handles all system interactions. The score management and audio logic are completely decoupled from the physics engine and simply react to system signals.

✅ **Data Driven Design**
Game balance parameters audio configurations and localization tables are managed through ScriptableObjects. This allows for rapid gameplay iterations without modifying the underlying source code.

---

## ⚡ Performance and Optimization

🚀 **Object Pooling**
Floating score labels are reused via a custom queue system. This minimizes CPU overhead and prevents memory spikes during intense gameplay sequences.

🚀 **Shader Prewarming**
Particle systems and materials are warmed up during the initialization phase. Every visual effect triggers smoothly without GPU related micro stutters.

🚀 **Smart Save System**
Cloud synchronization uses a throttling mechanism to write data only on specific events or timers. This reduces redundant network requests and optimizes platform resource usage.

---

## 💻 Tech Stack

🔹 **Engine** Unity 6 (URP)

🔹 **Code Style** Clean C# with Conventional Commits and Namespace based organization

🔹 **Input** New Unity Input System

🔹 **UI** UGUI with an adaptive layout for Mobile and Web platforms

🔹 **Physics** 2D Physics with custom collision filtering

---

## 📈 Roadmap

✅ Scene Independent Bootstrap
✅ Minimalist Dependency Injection
✅ Global Input Service
✅ Yandex Games SDK integration and Cloud Saves
✅ Combo system with dynamic audio pitch shifting
✅ Localization system RU and EN

---

## 👨‍💻 About the Developer

**Anton Kuzan** Unity Developer and UI UX Specialist.
Ex Lead Designer with 10+ years of experience in the IT industry now focusing on building high quality game architectures.

[LinkedIn](https://www.linkedin.com/in/antonkuzan)