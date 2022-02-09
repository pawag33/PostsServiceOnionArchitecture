# Posts Service Onion Architecture

This service created to compare two architecture approaches 3-Layer Architecture and Onion Architecture

Design Notes:
- DomainServices project can be splitted to two project Implementation and Interfaces to better losing  coupling 
- Post from domain entities can be an interface (IPost), this change can avoid type mapping from DB models to domain entities (if DB model will be implement IPost interface )
- Used anemic models since I believe that this approach give more flexibility 