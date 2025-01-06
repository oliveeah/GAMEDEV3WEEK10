using GameDevWithMarco.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Packages
{

    public class FallenObjectsSpawner : MonoBehaviour
    {
        [Header("Packages Spawn Position")]
        [SerializeField] GameObject[] spawners;
        [Header("Packages Delay Variables")]
        [SerializeField] float initialDelay = 2.0f;
        [SerializeField] float minDelay = 0.5f;
        [SerializeField] float delayIncreaseRata = 0.1f;
        float currentDelay;
        [Header("Packages Drop Chance Percentages")]
        [SerializeField] float goodPackageDropPercentage;
        [SerializeField] float badPackageDropPercentage;
        [SerializeField] float LifePackageDropPercentage;
        [SerializeField] float minimum_GoodPackagePercentage;
        [SerializeField] float maximum_BaddPackageDropPercentage;
        [SerializeField] float percentageChangeRatio = 0.1f;

    /*    //Referencing Gameobjects
        public GameObject[] spawners;
        public GameObject[] packages;
        //Timer Method Variables
        public float countdown = 3f;
        public float timer = 3f;
        public float timeBetweenPackages = 2f;
        //Deploy Method Variables
        private GameObject packageClone;
        public int packageRandomness;
        public int packageLocation;
        public bool hasBeenDeployed = false;
        public bool amIaGoodPackage = false;
        public float timerForLife = 15f;
        public GameObject lifePackage;*/


        void Start()
        {
            StartCoroutine(SpawningLoop());
        }

        // Update is called once per frame
        void Update()
        {
         /*   DeployLife();
            Countdown();
            AdaptiveDifficulty();
            countdown = Mathf.Clamp(countdown, 0, 10);
            timerForLife -= Time.deltaTime;*/
        }

        private void SpawnPackageAtRandomLocation(ObjectPoolingPattern.TypeOfPool poolType)
        {
            GameObject spawnedPackage = ObjectPoolingPattern.Instance.GetPoolItem(poolType);
            int randomInteger = Random.Range(0, spawners.Length-1);
            Vector2 spawnPosition = spawners[randomInteger].transform.position;
            spawnedPackage.transform.position = spawnPosition;
        }

        private IEnumerator SpawningLoop()
        {


            SpawnPackageAtRandomLocation(GetPackageTypeBasedOnPercentage());
            yield return new WaitForSeconds(currentDelay);
            currentDelay -= delayIncreaseRata;
            if (currentDelay < minDelay) currentDelay = minDelay;
            StartCoroutine(SpawningLoop());
        }

        private ObjectPoolingPattern.TypeOfPool GetPackageTypeBasedOnPercentage()
        {
            float randomValue = Random.Range(0f, 100.1f);
            if(randomValue <= goodPackageDropPercentage) 
            {
                return ObjectPoolingPattern.TypeOfPool.Good;
            }
            else if(randomValue > goodPackageDropPercentage && randomValue <= (goodPackageDropPercentage + badPackageDropPercentage))
            {
                return ObjectPoolingPattern.TypeOfPool.Bad;
            }
            else
            {
                return ObjectPoolingPattern.TypeOfPool.Life;
            }
        }

        private void CapThePercentages()
        {
            if(goodPackageDropPercentage <= minimum_GoodPackagePercentage & badPackageDropPercentage >= maximum_BaddPackageDropPercentage)
            {
                goodPackageDropPercentage = minimum_GoodPackagePercentage;
                badPackageDropPercentage = maximum_BaddPackageDropPercentage;
            }
        }

        public void GrowBadPercentage()
        {
            goodPackageDropPercentage -= percentageChangeRatio;
            badPackageDropPercentage -= percentageChangeRatio;
            CapThePercentages();
        }

        public void GrowGoodPercentage()
        {
            goodPackageDropPercentage += percentageChangeRatio;
            badPackageDropPercentage -= percentageChangeRatio;
            CapThePercentages();
        }

        /*private void InitialisationParameters()
        {
            countdown = Mathf.Clamp(timer, 0, 10);
        }
        private void Countdown()
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                DeployOrder();
            }
        }

        private void DeployOrder()
        {
            packageLocation = Random.Range(0, 4);
            packageRandomness = Random.Range(0, 10);

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DeployPackage_Beginning();
                timer = 3f;
            }
        }
        private void DeployPackage_Beginning()
        {
            switch (packageRandomness)
            {
                case 0:
                    Instantiate(packages[0], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 1:
                    Instantiate(packages[1], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = false;
                    break;
                case 2:
                    Instantiate(packages[2], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = false;
                    break;
                case 3:
                    Instantiate(packages[3], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 4:
                    Instantiate(packages[4], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 5:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 6:
                    Instantiate(packages[6], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 7:
                    Instantiate(packages[7], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 8:
                    Instantiate(packages[8], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 9:
                    Instantiate(packages[9], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 10:
                    Instantiate(packages[10], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;

            }

            hasBeenDeployed = true;
        }
        private void DeployPackage_Middle()
        {

            switch (packageRandomness)
            {
                case 0:
                    Instantiate(packages[0], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 1:
                    Instantiate(packages[1], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = false;
                    break;
                case 2:
                    Instantiate(packages[2], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = false;
                    break;
                case 3:
                    Instantiate(packages[3], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 4:
                    Instantiate(packages[4], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 5:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 6:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 7:
                    Instantiate(packages[7], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 8:
                    Instantiate(packages[8], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 9:
                    Instantiate(packages[9], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 10:
                    Instantiate(packages[10], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;

            }

            hasBeenDeployed = true;
        }
        private void DeployPackage_End()
        {

            switch (packageRandomness)
            {
                case 0:
                    Instantiate(packages[0], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 1:
                    Instantiate(packages[1], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = false;
                    break;
                case 2:
                    Instantiate(packages[2], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = false;
                    break;
                case 3:
                    Instantiate(packages[3], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 4:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 5:
                    Instantiate(packages[4], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 6:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 7:
                    Instantiate(packages[6], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 8:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 9:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;
                case 10:
                    Instantiate(packages[5], spawners[packageRandomness].transform.position, Quaternion.identity);
                    amIaGoodPackage = true;
                    break;

            }

            hasBeenDeployed = true;
        }
        private void DeployLife()
        {
            if (timerForLife <= 0)
            {
                Instantiate(lifePackage, spawners[packageLocation].transform.position, Quaternion.identity);
                timerForLife = Random.Range(12f, 20f);
            }
        }



        private void AdaptiveDifficulty()
        {
            if (GameManager.Instance.successRate < 3)
            {
                DeployCaseZero();
            }
            if (GameManager.Instance.successRate >= 6)
            {
                DeployCaseOne();
            }
            if (GameManager.Instance.successRate >= 9)
            {
                DeployCaseTwo();
            }
            if (GameManager.Instance.successRate >= 12)
            {
                DeployCaseThree();
            }
            if (GameManager.Instance.successRate >= 15)
            {
                DeployCaseFour();
            }
            if (GameManager.Instance.successRate >= 40)
            {
                DeployCaseFive();
            }
        }
        private void DeployCaseZero()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    DeployPackage_Beginning();
                    timer = 3f;
                }
            }
        }
        private void DeployCaseOne()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    DeployPackage_Beginning();
                    timer = 2f;
                }
            }
        }
        private void DeployCaseTwo()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    DeployPackage_Middle();
                    timer = 1f;
                }
            }
        }
        private void DeployCaseThree()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    DeployPackage_Middle();
                    timer = 0.5f;
                }
            }
        }
        private void DeployCaseFour()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    DeployPackage_End();
                    timer = 0.25f;
                }
            }
        }
        private void DeployCaseFive()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    DeployPackage_End();
                    timer = 0.10f;
                }
            }
        }*/

    }

}