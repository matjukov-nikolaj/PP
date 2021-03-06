// lw01.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <windows.h>
#include <cstdlib>
#include <ctime>
#include <iostream>
#include <vector>
#include <fstream>
#include <string>


using namespace std;


double GetDeterminant(vector<vector<double>> matrix, int size)
{
	long long c;
	double det = 0, s = 1;
	vector<vector<double>> b(matrix.size(), vector<double>(matrix.size()));
	long long i, j;
	long long m, n;
	if (size == 1)
	{
		return (matrix[0][0]);
	}

	else
	{
		det = 0;
		for (c = 0; c<size; c++)
		{
			m = 0;
			n = 0;
			for (i = 0; i<size; i++)
			{
				for (j = 0; j<size; j++)
				{
					b[i][j] = 0;
					if (i != 0 && j != c)
					{
						b[m][n] = matrix[i][j];
						if (n<(size - 2))
						{
							n++;
						}
						else
						{
							n = 0;
							m++;
						}
					}
				}
			}

			det = det + s * (matrix[0][c] * GetDeterminant(b, size - 1));
			s = -1 * s;
		}
	}
	return (det);

}

vector<vector<double>> ReadMatrixFromFile(const string &filePath, const size_t &matrixSize) {
	ifstream in(filePath);
	vector<vector<double>> result(matrixSize, vector<double>(matrixSize));

	for (size_t i = 0; i < matrixSize; ++i) {
		for (size_t j = 0; j < matrixSize; ++j) {
			in >> result[i][j];
		}
	}

	return result;
}

void PrintMatrix(vector< vector<double> > matrix) {
	int size = matrix.size();
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++) {
			cout << matrix[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl;
}


double GetPositiveDiagonal(const vector<vector<double>>& matrix, long long x) {
	double diagonal = 1;
	for (long long y = 0; y < matrix.size(); y++) {
		diagonal *= matrix[y][(x + y) % matrix.size()];
	}
	return diagonal;
}

double GetNegativeDiagonal(const vector<vector<double>>& matrix, long long x) {
	double diagonal = 1;
	for (long long y = 0; y < matrix.size(); y++) {
		diagonal *= matrix[y][(matrix.size() - y + x) % matrix.size()];
	}
	return diagonal;
}

double GetDeterminant(const vector<vector<double>>& matrix) {
	if (matrix.size() == 1) {
		return matrix[0][0];
	}

	if (matrix.size() == 2) {
		return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
	}

	double result = 0;

	for (long long x = 0; x < matrix.size(); x++) {
		result += GetPositiveDiagonal(matrix, x);
		result -= GetNegativeDiagonal(matrix, x);
	}

	return result;
}


vector<vector<double>> GetMinor(const vector<vector<double>>& matrix, long long row, long long col) {
	vector<vector<double>> result(matrix.size() - 1, vector<double>(matrix.size() - 1));
	long long xResult = -1;
	long long yResult = -1;
	for (long long x = 0; x < matrix.size(); x++) {
		if (x == col) {
			continue;
		}
		xResult++;
		for (long long y = 0; y < matrix.size(); y++) {
			if (y == row) {
				continue;
			}
			yResult++;
			result[yResult][xResult] = matrix[y][x];
		}
		yResult = -1;
	}
	return result;
}

void CalculateMinor(const vector<vector<double>> &matrix) {
	for (long long x = 0; x < matrix.size(); x++) {
		for (long long y = 0; y < matrix.size(); y++) {
			
		}
	}
}

double GetAlgebraicAddition(const vector<vector<double>> matrix, long long row, long long col) {
	vector<vector<double>> minor = GetMinor(matrix, row, col);
	return GetDeterminant(minor, minor.size()) * ((row + col) % 2 == 1 ? -1 : 1);
}

vector<vector<double>> GetBackMatrix(const vector < vector < double >> &matrix) {
	vector<vector<double>> result(matrix.size(), vector<double>(matrix.size()));

	double det = GetDeterminant(matrix, matrix.size());

	if (det < 0.01 && det > -0.01) {
		cout << "Determinant is equal zero" << endl;
		return result;
	}

	for (long long x = 0; x < matrix.size(); x++) {
		for (long long y = 0; y < matrix.size(); y++) {
			result[x][y] = GetAlgebraicAddition(matrix, y, x) / det;
		}
	}
	return result;
}

int main(int argc, char * argv[])
{
	unsigned long start = clock();
	if (argc != 4) {
		cout << "Incorrect number of parameters." << endl;
		cout << "lw01.exe <path/filename.extension> <matrix size> <number of threads>";
	}

	string filePath = argv[1];
	size_t matrixSize = stod(argv[2]);
	long long numberOfThreads = stod(argv[3]);

	try {
		vector<vector<double>> matrix = ReadMatrixFromFile(filePath, matrixSize);
		vector<vector<double>> back = GetBackMatrix(matrix);
		cout << "Success." << endl;
	}
	catch (exception &e) {
		cout << "Fail." << endl;
		cout << e.what() << endl;
		return -1;
	}
	unsigned long end = clock();

	cout << (end - start) << " ms." << endl;


    return 0;
}

