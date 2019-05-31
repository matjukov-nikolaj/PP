#include "Bank.h"

CBank::CBank(std::string primitive)
{
	m_clients = std::vector<CBankClient>();
	m_totalBalance = 0;
	m_primitive = primitive;

	InitializeCriticalSection(&m_criticalSection);
}

CBank::~CBank()
{
	DeleteCriticalSection(&m_criticalSection);
}

std::string CBank::GetPrimitive() {
	return m_primitive;
}

void CBank::Enter()
{
	if (CBank::GetPrimitive() == "cs") {
		EnterCriticalSection(&m_criticalSection);
	}
	else if (CBank::GetPrimitive() == "mutex") {
		m_mutex.lock();
	}
}

void CBank::Leave()
{
	if (CBank::GetPrimitive() == "cs") {
		LeaveCriticalSection(&m_criticalSection);
	}
	else if (CBank::GetPrimitive() == "mutex") {
		m_mutex.unlock();
	}
}

CBankClient* CBank::CreateClient()
{
	unsigned clientId = unsigned(m_clients.size());
	CBankClient* client = new CBankClient(this, clientId);
	m_clients.push_back(*client);
	m_balance[(*client).GetId()] = 0;
	return client;
}


void CBank::UpdateClientBalance(CBankClient &client, int value)
{
	Enter();
	int totalBalance = GetTotalBalance();
	std::cout << "Client " << client.GetId() << " initiates reading total balance. Total = " << totalBalance << "." << std::endl;
	
	SomeLongOperations();
	totalBalance += value;
	m_balance[(&client)->GetId()] += value;

	std::cout
		<< "Client " << client.GetId() << " updates his balance with " << value
		<< " and initiates setting total balance to " << totalBalance
		<< ". Must be: " << GetTotalBalance() + value << "." << std::endl;

	// Check correctness of transaction through actual total balance
	if (totalBalance != GetTotalBalance() + value) {
		std::cout << "! ERROR !" << std::endl;
	}

	SetTotalBalance(totalBalance);
	Leave();
}

std::vector<CBankClient> CBank::GetClients()
{
	return m_clients;
}


long CBank::GetTotalBalance()
{
	return m_totalBalance;
}

long CBank::GetBalance(long id)
{
	return m_balance[id];
}


void CBank::SetTotalBalance(int value)
{
	m_totalBalance = value;
}

void CBank::SomeLongOperations()
{
	// TODO
	Sleep(1000);
}