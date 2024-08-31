  mergeInto(LibraryManager.library, {


    ShowFullScreenAdvExtern: function () {
      ysdk.adv.showFullscreenAdv({
        callbacks: {
          onOpen: () => {
            gameInstance.SendMessage('YandexSDK', 'OnAdvShow');
          },
          onClose: function(wasShown) {
            gameInstance.SendMessage('YandexSDK', 'OnAdvClose');
          },
          onError: function(error) {
          // some action on error
            gameInstance.SendMessage('YandexSDK', 'OnAdvClose');
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

    ShowRewardedAdvExtern: function(){
      ysdk.adv.showRewardedVideo({
        callbacks: {
          onOpen: () => {
            gameInstance.SendMessage('YandexSDK', 'OnAdvShow');
          },
          onRewarded: () => {
            gameInstance.SendMessage('YandexSDK', 'OnRewarded');
          },
          onClose: () => {
            gameInstance.SendMessage('YandexSDK', 'OnAdvClose');
            console.log('Video ad closed.');
          }, 
          onError: (e) => {
            gameInstance.SendMessage('YandexSDK', 'OnAdvClose');  
            console.log('Error while open video ad:', e);
          }
        }
      })
    },
        ShowDoubleRewardedAdvExtern: function(){
      ysdk.adv.showRewardedVideo({
        callbacks: {
          onOpen: () => {
            gameInstance.SendMessage('YandexSDK', 'OnAdvShow');
          },
          onRewarded: () => {
            gameInstance.SendMessage('YandexSDK', 'OnDoubleRewarded');
          },
          onClose: () => {
            gameInstance.SendMessage('YandexSDK', 'OnAdvClose');
            console.log('Video ad closed.');
          }, 
          onError: (e) => {

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
        gameInstance.SendMessage('YandexSDK','InitData', myJSON);
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