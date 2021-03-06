# Examination project 22: Variational method with Lagrange multipliers

#### Author: 
Thorbjørn Madsen
#### Student number: 
201905722 --> 22 % 23 = 22

#### Project description:
This project revolves around a mathematical concept called constrained optimization, where the problem is to determine the eigenvalue and the corresponding eigenvector of a real symmetric matrix A. Concerning physics and quantum mechanics you often would like to know the groundstate energy of a specific system, and as a method to get an approximate value you could use the variational method. In this case, you want to minimize the energy (the eigenvalue), so that the energy is as close to the groundstate energy as possible. So in our case, we are given a multivariable function 
$$E(\textbf{v})=\textbf{v}^{T} A \textbf{v}$$ 
which is a function of the vector $\textbf{v}$, that consists of n variables. The function is subject to the constraint that 
$\textbf{v}^{T}\textbf{v}=1$. 
This function is the one we would like to minimize, to do this we then search for the stationary point with the use of Lagrange multipliers, i.e. using the Lagrangian function:
$$L(\textbf{v},\lambda) = \textbf{v}^{T}A\textbf{v} - \lambda(\textbf{v}^{T}\textbf{v}-1)$$
At the stationary point all the partial derivatives of the Lagrangian should be 0, using the variables 
${\textbf{v},\lambda}$. 
For the search of this stationary point we find the root in the n+1 dimensional space 
$\textbf{x} = (\textbf{v}, \lambda)$ of the n+1 dimensional vector function
$$\textbf{f}(\textbf{x}) = (A\textbf{v} - \lambda \textbf{v}, \textbf{v}^T\textbf{v}-1)$$

To implement this I have used Newton's method for root-finding and the QR Gram-Schmidt decomposition for solving linear equations. These two algorithms are available to look at in homework/root-finding and homework/linear-equations respectively. Other files are also used in the implementation, these files can be seen in the Makefile.

Newton's method which was implemented in the roots homework has been modified and is thus called rootsLM.cs. The reason for this is that an analytical expression for the Jacobian matrix of the n+1 dimensional vector function (the function $\textbf{f}$ above) exists, hence this analytical expression has been implemented and is used instead of the numerical finite differences. This change along with some comments on the implementation can be seen in rootsLM.cs

The routine that calculates the eigenvalue and the corresponding eigenvector of a given symmetric real matrix A can be seen in the file lagrangeMult.cs. In short, this file includes a method that takes the matrix A and an initial guess for the eigenvalue as arguments, then it returns an eigenvalue close to the guess along with the corresponding eigenvector. 
In the method, the n+1 vector function $\textbf{f}$ is introduced, and this function is used in the modified root-finding routine. The function uses the components of the eigenvector and put them into the partial derivatives of the Lagrangian function at the stationary point, i.e. in the function 
$\textbf{f}(\textbf{x})$. 
The root-finding routine determines the root of this function by using a backtracking line search, and in the end returns a vector of n+1 dimension, which constitutes the eigenvector components and the eigenvalue 
$\lambda$ as the last n+1'th component. 
Due to the constraint $\textbf{v}^T\textbf{v}=1$, the corresponding eigenvector 
$\textbf{v}$ of the eigenvalue $λ$
at the stationary point is normalized.

The main.cs file contains a main method that tests the above-mentioned implementation. The main method creates a random symmetric real 4x4 matrix and determines its eigenvalue and corresponding eigenvector. To test that the eigenvalue and eigenvector are correct, they should fulfill the eigenvalue equation for the matrix, and the eigenvector should fulfill the constraint. The result of this test is seen in the out.txt file. 

#### Self-evaluation:
I would consider this examination project to be a success since it succeeds in determining the eigenvalue and the corresponding eigenvector of a random symmetric real 4x4 matrix, and the eigenvalue and eigenvector fulfill the eigenvalue equation and the constraint. One thing I thought was a bit unclear was whether Newton's root-finding method also should include an approximation such as a rank-1 update. Thus, the root-finding routine would be qualified as a quasi-Newton root-finding routine. I decided though to only customize Newton's method such that it used the analytical expression for the Jacobian instead of the numerical finite differences. Anyways the project, I hope, should be qualified as passed. To test the implementation further, the groundstate energy of the Hydrogen atom could be calculated for example. 
