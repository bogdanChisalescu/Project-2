clear all;
close all;
clc;

%Masuratoarea efectuata asupra senzorului
%de umiditate a solului
Um = [ 0  20  40  60  80  100];
Vout = [4.93  4.43  2.68  1.75  1.25  1.14];
figure(1), plot(Um, Vout, 'o'), hold on
title('Masuratoarea de etalonare - senzor de nivel al apei'), 
xlabel('Umiditatea solului [%]'), ylabel('Tensiunea de iesire [V]')


Y = polyfit(Um, Vout, 1)
x = linspace(0, 100);
z = Y(1) * x + Y(2);
plot(x,z)