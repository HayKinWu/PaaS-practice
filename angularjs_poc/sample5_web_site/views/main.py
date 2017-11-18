#!/usr/bin/env python
# -*- coding: utf-8 -*-

from flask import render_template, redirect, request, url_for, flash
from flask.views import MethodView
import json

class Main(MethodView):

  def get(self):
    return render_template('index.html')
