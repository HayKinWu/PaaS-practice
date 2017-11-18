#!/usr/bin/env python
# -*- coding: utf-8 -*-

import os
from flask import Flask
from views.main import Main
from views.api.todo import Todo
app = Flask(__name__)
# important
app.jinja_env.variable_start_string = '%%'
app.jinja_env.variable_end_string = '%%'

app.config['SECRET_KEY'] = "A0Zr98j/3yX R~XHH!jmN]LWX/,?RT"

# Route
app.add_url_rule('/', view_func = Main.as_view("main"), methods=["GET"])

todo_view = Todo.as_view('todo')

app.add_url_rule('/api/todo', view_func= todo_view, methods=["GET","POST","PUT","DELETE"])

# Create (新增)=> Post
# Retrieve (取值,查詢 )=> Get
# Update (更新 ) => Put
# Delete ( 刪除 ) => Delete
