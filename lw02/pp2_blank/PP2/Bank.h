#pragma once
#include <iostream>
#include <vector>
#include <unordered_map>
#include <mutex>
#include "BankClient.h"

class CBank
{
public:
	CBank(std::string primitive);
	~CBank();
	CBankClient* CreateClient();
	void UpdateClientBalance(CBankClient& client, int value);
	std::vector<CBankClient> GetClients();
	long GetTotalBalance();
	long GetBalance(long id);
	std::string GetPrimitive();

private:
	std::vector<CBankClient> m_clients;
	std::unordered_map<unsigned, long> m_balance;
	int m_totalBalance;
	std::string m_primitive;
	CRITICAL_SECTION m_criticalSection;
	std::mutex m_mutex;
	
	void Enter();
	void Leave();

	void SetTotalBalance(int value);
	void SomeLongOperations();
};