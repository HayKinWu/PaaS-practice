#!/usr/bin/env python
# -*- coding: utf-8 -*-

from flask import render_template, redirect, request, url_for, flash, Response
from flask.views import MethodView
import json

class User(MethodView):

  def get(self):
    name = request.args.get('name', None)

    if name is None:
      return Response('', status=500, mimetype='application/json')

    data = {
      'user_id': 1,
      'name'  : name,
    }

    js = json.dumps(data)
    resp = Response(js, status=200, mimetype='application/json')

    return resp

  def post(self):
    pass

  def put(self):
    pass
  def delete(self):
    pass
