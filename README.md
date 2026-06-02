# Enterprise Credit Control & Commercial Management Module

A data-driven B2B Credit Control and Financial Risk module designed to automate customer credit lines, track aging debt, and secure company cash flow. This system bridges real-world commercial back-office operations with a modern enterprise backend architecture.

🚀 **Status:** In Progress (Database Architecture & API Design)

---

## 🎯 Core Business Use Cases

This system automates the critical financial workflows utilized by commercial controllers to evaluate and mitigate customer credit risk:

### 1. Automated Credit Checking & Order Blocking
Before a sales order is finalized, the system calculates the real-time financial exposure:  
`Exposure = Current Outstanding Balance + New Order Value`  
If this exceeds the customer's allocated **Credit Limit**, the system flags the transaction as `Blocked: True`, freezing the order until a credit controller reviews it.

### 2. Invoice Aging Analysis & Weekly Email Alerts
A background worker automatically scans open invoices daily and maps outstanding debt into chronological risk buckets: *0-30 days, 31-60 days, 61-90 days, and 90+ days overdue*. 

*   **Risk Flagging:** Customers with invoices breaching the 90+ day threshold are automatically flagged as **High Risk**, suspending their purchasing privileges.
*   **Weekly Controller Digest:** Every Monday morning, a scheduled background service aggregates the data and sends an **automated HTML email notification** to management, listing all blocked accounts, critical overdue invoices, and top financial risks for the week.

### 3. Credit Limit Overrides & Audit Logging
To accommodate urgent business operations, authorized Credit Controllers can issue credit exceptions (e.g., a 48-hour limit extension). The backend securely processes these overrides and logs the supervisor's ID, timestamp, and justification into an immutable **Audit Log**.

### 4. Cash Allocation & Debt Clearing (FIFO Algorithm)
When a customer payment is received, the system executes a **FIFO (First-In, First-Out)** clearing engine. Payments are automatically allocated to settle the oldest outstanding invoices first, lowering the customer's aging debt profile and instantly recalculating their available credit space.

---

## 🛠 Tech Stack & Architecture

*   **Backend Engine:** .NET Core (Web API & Background Worker Services)
*   **Database:** PostgreSQL (Relational schema optimized for transactional integrity and indexing)
*   **Frontend UI:** React (Operational dashboard for Credit Controllers)
*   **Patterns:** Clean Architecture, Repository Pattern, Async Background Processing

## 🗺 Roadmap

- [ ] **Phase 1: Database Design** – Entity relations for Customers, Invoices, Credit Profiles, and Audit Logs (PostgreSQL).
- [ ] **Phase 2: Core Engine & FIFO Logic** – Building the background worker services to recalculate risk profiles and process cash allocations.
- [ ] **Phase 3: RESTful API & Automated Notifications** – Developing endpoints to simulate ERP sales order requests and controller approvals, and integrating a scheduled SMTP service for weekly email alerts.
- [ ] **Phase 4: Controller Dashboard** – React UI for manual overrides, invoice tracking, and risk analysis visualizations.

---
License: [MIT](LICENSE)
