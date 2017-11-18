#!/usr/bin/env python
# -*- coding: utf-8 -*-

from flask import render_template, redirect, request, url_for, flash, Response
from flask import session
from flask.views import MethodView
import json

class Todo(MethodView):

  def get(self):

    # if no date, create new data for sample
    if 'todo' not in session:
      session['todo'] = [
        {'text':'learn AngularJS', 'done':True},
        {'text':'build an AngularJS app', 'done':False}
      ]
      print "no data, create new sample data"
    elif len(session['todo']) == 0:
      session['todo'] = [
        {'text':'learn AngularJS', 'done':True},
        {'text':'build an AngularJS app', 'done':False}
      ]
      print "no data, create new sample data"
    # dump data from session
    print session['todo']
    js = json.dumps(session['todo'])
    resp = Response(js, status=200, mimetype='application/json')

    return resp

  def post(self):

    obj = json.loads(request.data)
    print session['todo']
    try:
      session['todo'].append(obj)
    except:
      session['todo']=[obj]

    print session['todo']

    js = json.dumps(obj)
    resp = Response(js, status=200, mimetype='application/json')

    return resp

  def put(self):
    pass
  def delete(self):
    pass
