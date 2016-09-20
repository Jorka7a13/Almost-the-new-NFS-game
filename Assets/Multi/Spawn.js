var playerPrefab1 : Transform;
var playerPrefab2 : Transform;
var playerPrefab3 : Transform;
var playerPrefab4 : Transform;
var playerPrefab5 : Transform;


var megachoice:int =1;


function Start() {


}

function OnNetworkLoadedLevel ()
{

		if (MultiChose.choice_ == 1)
		{

			Network.Instantiate(playerPrefab1, transform.position, transform.rotation, 0);
		}
		if (MultiChose.choice_ == 2)
		{
			Network.Instantiate(playerPrefab2, transform.position, transform.rotation, 0);

		}
		if (MultiChose.choice_ == 3)
		{
			Network.Instantiate(playerPrefab3, transform.position, transform.rotation, 0);

		}
		if (MultiChose.choice_ == 4)
		{
			Network.Instantiate(playerPrefab4, transform.position, transform.rotation, 0);

		}
		if (MultiChose.choice_ == 5)
		{
			Network.Instantiate(playerPrefab5, transform.position, transform.rotation, 0);

		}




		

}

function OnPlayerDisconnected (player : NetworkPlayer)
{
	Debug.Log("Server destroying player");
	Network.RemoveRPCs(player, 0);
	Network.DestroyPlayerObjects(player);
}
