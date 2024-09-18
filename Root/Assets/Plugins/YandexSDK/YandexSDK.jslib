  mergeInto(LibraryManager.library, {


    ShowFullScreenAdvExtern: function () {
      ysdk.adv.showFullscreenAdv({
        callbacks: {
          onOpen: () => {
            gameInstance.SendMessage('JSProvider', 'OnAdvShow');
          },
          onClose: function(wasShown) {
            gameInstance.SendMessage('JSProvider', 'OnAdvClose');
          },
          onError: function(error) {
          // some action on error
            gameInstance.SendMessage('JSProvider', 'OnAdvClose');
          }
        }
      })
    },

    RateGameExtern: function () {
      ysdk.feedback.canReview()
      .then(({ value, reason }) => {
        if (value) {
          ysdk.feedback.requestReview()
          .then(({ feedbackSent }) => {
            console.log(feedbackSent);
          })
        } else {
          console.log(reason)
        }
      })
    },

    ShowRewardedAdvExtern: function(id){
      ysdk.adv.showRewardedVideo({
        callbacks: {
          onOpen: () => {
            gameInstance.SendMessage('JSProvider', 'OnAdvShow');
          },
          onRewarded: () => {
            gameInstance.SendMessage('JSProvider', 'OnRewarded', id);
          },
          onClose: () => {
            gameInstance.SendMessage('JSProvider', 'OnAdvClose');
            console.log('Video ad closed.');
          }, 
          onError: (e) => {
            gameInstance.SendMessage('JSProvider', 'OnAdvClose');  
            console.log('Error while open video ad:', e);
          }
        }
      })
    },

    UpdateLeaderboardExtern: function (value) {
      ysdk.getLeaderboards()
      .then(lb => {
        lb.setLeaderboardScore('Sample', value);
      });
    },

    SaveDataExtern: function (data) {
      var dataString = UTF8ToString(data);
      var myobj = JSON.parse(dataString);
      player.setData(myobj);
    },
    LoadDataExtern: function () {

      player.getData().then(_data => {
        const myJSON = JSON.stringify(_data);
        gameInstance.SendMessage('JSProvider','InitData', myJSON);
      });
    },

    GetLanguageExtern: function () {
      var lang = ysdk.environment.i18n.lang;
      var bufferSize = lengthBytesUTF8(lang) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(lang, buffer, bufferSize);
      return buffer;
    },

    GameReadyExtern: function () {
      ysdk.features.LoadingAPI.ready()
    },
  });