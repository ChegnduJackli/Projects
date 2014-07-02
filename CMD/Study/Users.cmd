::create user
net user lideng Jack1234 /add

::adminstrator access
net localgroup administrators lideng /add

::change user password
net user lideng *
