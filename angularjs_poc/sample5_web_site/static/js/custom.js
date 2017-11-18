
'use restrict'

var myApp = angular.module('myApp',[]);

myApp.config(function($logProvider){
  $logProvider.debugEnabled(true);
});

myApp.controller('TodoListController', ['$scope','$http',function($scope,$http) {
  var todoList = this;

  $scope.todoList.todos = [];

  $http.get('/api/todo')
  .then(function success(response) {
      console.log(response);
      $scope.todoList.todos = response.data;
   },function error(response) {
      // no data
      alert("Call API FAIL") ;
      $scope.todoList.todos = [];
   });

  $scope.todoList.addTodo = function() {

    data = {text:$scope.todoList.todoText, done:false}
    $http.post('/api/todo',data)
    .then(function success(response) {
      $scope.todoList.todos.push( data);
    },function error(response) {
        alert("Call Restful API todo post FAIL") ;
    });


    $scope.todoList.todoText = '';
  };

  $scope.todoList.remaining = function() {
    var count = 0;
    angular.forEach($scope.todoList.todos, function(todo) {
      count += todo.done ? 0 : 1;
    });
    return count;
  };

  $scope.archive = function() {
    var oldTodos = $scope.todoList.todos;
    $scope.todoList.todos = [];
    angular.forEach(oldTodos, function(todo) {
      if (!todo.done) $scope.todoList.todos.push(todo);
    });
  };
}]);
