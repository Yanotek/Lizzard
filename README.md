# Lizzard
Небольшая программа для удаленного взаимодействия с комп. клиента. v 0.01;

Ужасно сырая. Для взаимодействия, перед компиляцией надо руками прописать ip адрес в коде.
Для сервера в классе Configurations, для клиента в классе Program.cs

На данный момент 2 функции: вывод окошка сообщений на стороне клиента и показ удаленного экрана по протоколу RDP
Сейчас нет автоматического добавления в список разрешений брандмауэра.

На стороне клиента программа запускается в скрытом режиме, и постоянно пытается приконектиться к серверу.