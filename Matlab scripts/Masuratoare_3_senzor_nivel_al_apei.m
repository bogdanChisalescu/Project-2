clear all;
close all;
clc;

%A treia masuratoare efectuata asupra senzorului
%de nivel al apei
Dif = 5;
Vcc = [ 3.5  3.57  3.3  3.22  3.22  3.18  3.16  3.16  3.16  3.16  3.16  3.16  3.17];
avgVcc = mean(Vcc)
Hvas = [ 5  7  12  15  17  22  25  29  32  35  39  43  47];
Hs = Hvas - Dif;
Vout = [0  1.13  1.48  1.62  1.66  1.73  1.76  1.78  1.79  1.81  1.82  1.82  1.8];
Vout_posibil = [0  1.13  1.48  1.62  1.66  1.73  1.76  1.78  1.79  1.81  1.82  1.82  1.8];
figure(1), plot(Hs, Vout, 'o'), hold on
title('A treia masuratoare de etalonare - senzor de nivel al apei'), 
xlabel('Inaltimea coloanei de apa [mm]'), ylabel('Tensiunea de iesire [V]')

Y = polyfit(Hs, Vout, 1)
x = linspace(0, 45);
z = Y(1) * x + Y(2);
plot(x,z)