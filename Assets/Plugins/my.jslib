mergeInto(LibraryManager.library, {

	SaveExtern: function(date) {
    	var dateString = UTF8ToString(date);
    	var myobj = JSON.parse(dateString);
    	player.setData(myobj);
  	},

  	LoadExtern: function() {
		YaGames.init().then(ysdk => {
			ysdk.getPlayer({ scopes: false }).then(_player => {
				player = _player;		
				player.getData().then(_date => {
					const myJSON = JSON.stringify(_date);
					myGameInstance.SendMessage('SaveManager', 'SetData', myJSON);
					myGameInstance.SendMessage('SaveManager', 'LoadedData');
				});
			}).catch(err => {
				// Ошибка при инициализации объекта Player.
			});
		});
 	},
  });