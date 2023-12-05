//
//  FilterButtonView.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import SwiftUI

struct FilterButtonView: View {
    var body: some View {
        RoundedRectangle(cornerRadius: 10)
            .frame(width: 40, height: 40)
            .foregroundColor(.red)
            .overlay {
                Image(systemName: "line.3.horizontal.decrease")
                    .foregroundColor(.white)
            }
    }
}

struct FilterButtonView_Previews: PreviewProvider {
    static var previews: some View {
        FilterButtonView()
    }
}
