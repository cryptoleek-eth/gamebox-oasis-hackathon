// contracts/FlappyBirdLeaderboard.sol
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

import "@openzeppelin/contracts/access/Ownable.sol";

contract FlappyBirdLeaderboard is Ownable {

  // lists top 10 users
  uint leaderboardLength = 10;

  // create an array of Users
  mapping (uint => User) public leaderboard;

  // each user has a username and score
  struct User {
    address user;
    uint score;
  }

  constructor() {

  }

  // owner calls to update leaderboard
  function addScore(address user, uint score) onlyOwner public {
    require(score >= leaderboard[leaderboardLength-1].score, "Score too low");

    // loop through the leaderboard
    for (uint i=0; i<leaderboardLength; i++) {
      // find where to insert the new score
      if (leaderboard[i].score < score) {

        // shift leaderboard
        User memory currentUser = leaderboard[i];
        for (uint j=i+1; j<leaderboardLength+1; j++) {
          User memory nextUser = leaderboard[j];
          leaderboard[j] = currentUser;
          currentUser = nextUser;
        }

        // insert
        leaderboard[i] = User({
          user: user,
          score: score
        });

        // delete last from list
        delete leaderboard[leaderboardLength];

        break;
      }
    }
  }
}