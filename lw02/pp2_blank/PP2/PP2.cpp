#include "stdafx.h"
#include "Bank.h"
#include "BankClient.h"
#include <string>
#include <iostream>

int main(int argc, char *argv[])
{
	int clientNumbers = 2;
	std::string primitive = "";
	if (std::string(argv[1]) == "/?") {
		std::cout << "Usage: PP2.exe <number of clients> <primitive>" << std::endl;
		std::cout << "Primitive: cs - criticalsection, mutex- mutex" << std::endl;
		return 0;
	}
	if (argc == 2) {
		clientNumbers = atoi(argv[1]);
	}
	if (argc = 3) {
		clientNumbers = atoi(argv[1]);
		primitive = argv[2];
	}
	CBank* bank = new CBank(primitive);
	for (int i = 0; i < clientNumbers; ++i) {
		CBankClient* client = bank->CreateClient();
	}

	for (;;) {
		std::string in;
		std::getline(std::cin, in);
		if (in == "quit" || in == "exit") {
			break;
		}


	}

	long sum = 0;
	std::cout << "Clents Info: " << "\n";
	for (auto client : bank->GetClients()) {
		int balance = bank->GetBalance(client.GetId());
		std::cout << "	Client Id: " << client.GetId() << "\n";
		std::cout << "		Balance: " << balance << "\n";
		sum += balance;
	}
	std::cout << "Clients balance: " << sum << "\n";
	std::cout << "Bank balance: " << bank->GetTotalBalance() << "\n";
	// TODO: WaitForMultipleObjects

    return 0;
}